import React, { useState, useEffect } from 'react';
import { allowedColors } from "../allowedColors";
import { Hint } from 'react-autocomplete-hint';
import TableSections from './Tables/TableSections';
import Chart from './Chart/Chart';

const Home  = () => {
  const [stateColorName , setStateColorName] = useState("")
  const colorChangeHandler = (event) => setStateColorName(event.target.value);

  const handleRequestClick = () => {
    const formData = new FormData();
    if (stateColorName !== ""){

      const name = stateColorName.charAt(0).toUpperCase() + stateColorName.slice(1);

      if(allowedColors.includes(name)){
        console.log(name)
        var data = new FormData();
        
        data.append("color", name);
        fetch('api/Color/CreateUpdateColor/'+name, {
            method: 'POST'
        }).then(response => response.text())
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

              <button className="btn btn-outline-success" onClick={handleRequestClick}>
                <i class="fa fa-paper-plane" aria-hidden="true"></i>
              </button>

              <Chart />

            </div>

            <div className="col" style={{float: "right"}}>
            <TableSections />
            </div>
          </div>
        </div>
      </div>
    );

}
export default Home
