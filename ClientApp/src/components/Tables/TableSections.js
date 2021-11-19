import React, { useEffect, useState } from 'react'
import "./Table.css"

function TableSections(){
    const [fiveMinutesLeft, setFiveMinutesLeft] = useState(30);
    const [colors , setColors] = useState([])

	useEffect(() => {
        async function fetchData() {
            // You can await here
            const response = await fetch('api/Color/GetAllColors');
            const data = await response.json();
            setColors(data);
            // ...
        }
        
        
        if (fiveMinutesLeft > 0) {
        const timerId = setTimeout(() => {
            setFiveMinutesLeft(fiveMinutesLeft - 1);
            fetchData();
        }, 1000);
            return () => clearTimeout(timerId);
        } else {
            fetch('api/Color/updateRefresh', {
                method: 'POST'
            }).then(response => response.text())

            setFiveMinutesLeft(10)
        }
    });

    const addCurrentColorTable = async (name) => {
        await fetch('api/Color/CreateUpdateColor/'+name, {
            method: 'POST'
        }).then(response => response.text())
    }

    const subCurrentColorTable = async (id) => {
        await fetch('api/Color/SubractCurrentColor/'+id, {
            method: 'POST'
        }).then(response => response.text())
    }

    const deleteColor = async (id) => {
        await fetch('api/Color/DeleteColor/'+id, {
            method: 'POST'
        }).then(response => response.text())
    }
    
    const SortAndGroup = (type) => {
        const colorRows = [];
        colors.map(color => {
            if(type === color.type){
                const row = (
                    <tr key={color.id}>
                        <th scope="row" style={{ color: color.name }}>{color.name}</th>
                        <td style={{ color: color.name }}> 
                            <i class="fa fa-plus" aria-hidden="true" onClick={() => addCurrentColorTable(color.name)}></i> 
                             {color.counter}
                            <i class="fa fa-minus" aria-hidden="true" onClick={() => subCurrentColorTable(color.id)}></i> 
                        </td>
                        <i class="fa fa-trash-o" aria-hidden="true" onClick={() => deleteColor(color.id)}></i>
                    </tr>
                );
                colorRows.push(row);
            }
        })
        return colorRows
    }

    const displayTime = (seconds) => {
        const format = val => `0${Math.floor(val)}`.slice(-2)
        const hours = seconds / 3600
        const minutes = (seconds % 3600) / 60
      
        return [hours, minutes, seconds % 60].map(format).join(':')
    }
    return(
        
        <table >
            <thead>
            <tr>
                <th scope="col">Trending</th>
                <th scope="col">Popular</th>
                <th scope="col">Up and Coming</th>
            </tr>
            </thead>
            
            <tfoot>
            <tr>
                <td colSpan="3">Data will refresh in {displayTime(fiveMinutesLeft)}</td>
            </tr>
            </tfoot>
            <tbody>
            <tr>
                <td>{SortAndGroup("trending")}</td>
                <td>{SortAndGroup("popular")}</td>
                <td>{SortAndGroup("upAndComing")}</td>
            </tr>
            </tbody>
      </table>
    )
}

export default TableSections;
