import { useEffect } from "react";
import React, { Component }  from 'react';
import { useState } from "react";
import Cities from "./Cities";

const Countries = ({onHandleButtonClick, onCitySelect, selectedCity}) => {
  const [countriesList, setCountriesList] = useState([]);
  const [selectedCountry, setSelectedCountry] = useState("");
  const defaultOption = "select a country";

  useEffect(() => {
    fetch('countries')
      .then(results => results.json())
      .then(data => {
        setCountriesList(data);
      });

  }, []);
  
  return (
    <div>
        <h2>
        {selectedCountry ? "" : "Pick a country"}</h2>
      <select
        onChange={(e) => {
            if(e.target.value !== defaultOption){
                setSelectedCountry(e.target.value);
            }
        }}
        defaultValue={selectedCountry}
      >
        <option>{defaultOption}</option>
        {countriesList.map((option, idx) => (
          <option key={idx}>{option}</option>
        ))}
      </select>
      
      {selectedCountry ? 
      <Cities
      selectedCountry={selectedCountry}
      onHandleButtonClick={onHandleButtonClick}
      onCitySelect={onCitySelect}
      selectedCity={selectedCity}/>
      :
      <></>}

    </div>
);
}

export default Countries;