import React, { useState, useEffect } from 'react';
import { allowedColors } from "../allowedColors";
import { Hint } from 'react-autocomplete-hint';
import TableSections from './Tables/TableSections';
import Chart from './Chart/Chart';

const Home  = (props) => {
  const { updateErrorMessage } = props
  const [stateColorName , setStateColorName] = useState("")
  const colorChangeHandler = (event) => setStateColorName(event.target.value);

  const handleRequestClick = async(namePassed) => {
    if (namePassed !== ""){

      const name = namePassed.charAt(0).toUpperCase() + namePassed.slice(1);

      if(allowedColors.includes(name)){
        console.log(name)
        var data = new FormData();
        //Response { type: "basic", url: "https://localhost:5001/api/Colr/CreateUpdateColor/Red", redirected: false, status: 404, ok: false, statusText: "Not Found", headers: Headers, body: ReadableStream, bodyUsed: false }
        
        data.append("color", name);
        await fetch('api/Color/CreateUpdateColor/'+name, {
            method: 'POST'
        }).then(response => {
          if (response.status !== 200){
            updateErrorMessage(`There was a problem with your request, the request is ${response.statusText}`);
          } else {
            updateErrorMessage(null)
          }
        })
      } else {
        updateErrorMessage(`${name} is not on our list as color`);
      }
    }
  }
  
    return (
      <div>
        <div className="container">
          <div className="row">
            <div className="col col-4 threeButton">
              <Hint options={allowedColors}>
                <input type="text"
                  name="color"
                  id="color"
                  style={{
                    width: "100%",
                    margin: 0,
                  }}
                  className="form__input"
                  value={stateColorName}
                  placeholder="Request/Delete/Edit color"
                  onChange={colorChangeHandler}
                />
              </Hint><br />

              <button className="btn btn-outline-success" onClick={ ()=> {handleRequestClick(stateColorName)}}>
                <i class="fa fa-paper-plane" aria-hidden="true"></i>
              </button>

              <Chart />

            </div>

            <div className="col" style={{float: "right"}}>
            <TableSections handleRequestClick={handleRequestClick}/>
            </div>
          </div>
        </div>
      </div>
    );

}
export default Home
