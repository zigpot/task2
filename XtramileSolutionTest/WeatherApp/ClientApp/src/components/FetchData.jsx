import React, { Component, useEffect, useState } from 'react';
import Countries from './Countries';

const FetchData = () => {
  const [forecast, setForecast] = useState();
  const [loading, setLoading] = useState(true);
  const [selectedCity, setSelectedCity] = useState("");

  async function populateWeatherData() {
    const response = await fetch('weatherparams?city=' + selectedCity);
    const data = await response.json();
    setForecast(data);
    setLoading(false);
  }

  const onHandleButtonClick = () => {
    populateWeatherData(selectedCity);
  }

  useEffect(()=>{
    //populateWeatherData(selectedCity);
  },[]);

  const forecastsTable = (forecast) => {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Location</th>
            <th>Time</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Wind (km/h)</th>
            <th>Visibility (km)</th>
            <th>Sky Condition</th>
            <th>Dew Point (°C Td)</th>
            <th>Relative Humidity (%)</th>
            <th>Pressure (hPa)</th>
          </tr>
        </thead>
        <tbody>
          {
            <tr key={forecast.date}>
              <td>{forecast.location}</td>
              <td>{((forecast.time).split("T")[1]).split(".")[0]}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.wind}</td>
              <td>{forecast.visibility}</td>
              <td>{forecast.skyCondition}</td>
              <td>{forecast.dewPoint}</td>
              <td>{forecast.relativeHumidity}</td>
              <td>{forecast.pressure}</td>
            </tr>
          }
        </tbody>
      </table>
    );
  }
  

  return (
    <div>
      <h1 id="tabelLabel" >Current Weather</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {loading
    ? <p><em>Loading...</em></p>
    : forecastsTable(forecast)}
      <Countries
      onHandleButtonClick={onHandleButtonClick}
      onCitySelect={setSelectedCity}
      selectedCity={selectedCity}/>
    </div>
  );
}

export default FetchData;