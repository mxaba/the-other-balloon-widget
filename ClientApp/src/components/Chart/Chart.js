import React, { useState, useEffect } from 'react';
import {Doughnut} from 'react-chartjs-2';

function Chart() {
  const [colors , setColors] = useState([])

  useEffect(() => {
    async function fetchData() {
        // You can await here
        const response = await fetch('api/Color/GetAllColors');
        const data = await response.json();
        setColors(data);
        // ...
    }
    fetchData();
});

  const labelColors = (namePassed) =>{
    const newArray = []
    if (namePassed === "data" ){
      colors.forEach(color => {
        newArray.push(color.counter)
      })
    } else { 
      colors.forEach(color => {
        newArray.push(color.name)
      })
    }
    return newArray
  }

  const state = {
    labels: labelColors(),
    datasets: [
      {
        label: 'Rainfall',
        backgroundColor: labelColors(),
        hoverBackgroundColor: labelColors(),
        data: labelColors("data")
      }
    ]
  }

  return (
    <div className="chart">
      <Doughnut
        data={state}
            options={{
              title:{
                display:true,
                text:'Average Color request per user',
                fontSize:20
              },
              legend:{
                display:true,
                position:'right'
              }
            }}
        />
    </div>
  );
}

export default Chart;