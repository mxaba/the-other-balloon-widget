import React, { useState } from 'react';
import { allowedColors } from "../allowedColors";
import { Hint } from 'react-autocomplete-hint';

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
        // formData.append(JSON.stringify(name));
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

              <button className="btn btn-outline-danger" >
                <i class="fa fa-trash-o" aria-hidden="true"></i>
              </button>

            </div>
          </div>
        </div>
      </div>
    );

}
export default Home
