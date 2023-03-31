import { useEffect } from "react";
import React, { Component }  from 'react';
import { useState } from "react";

const Cities = ({selectedCountry, onHandleButtonClick, onCitySelect, selectedCity}) => {
  const [citiesList, setCitiesList] = useState([]);
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const defaultOption = "select a city";

  useEffect(() => {
    fetch('cities?country=' + selectedCountry)
      .then(results => results.json())
      .then(data => {
        setCitiesList(data);
      });

  }, [selectedCountry]);

  return (
      <>
      <select
        onChange={(e) => {
            if(e.target.value !== defaultOption){
                onCitySelect(e.target.value);
                setButtonDisabled(false);
        }
        }}
        defaultValue={selectedCity}
      >
        <option >{defaultOption}</option>
        {citiesList.map((option, idx) => (
          <option key={idx}>{option}</option>
        ))}
      </select>
      <button disabled={buttonDisabled} onClick={onHandleButtonClick} >Send</button>
      </>
      );
}

export default Cities;