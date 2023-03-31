import React, { Component } from 'react';
import Countries from './Countries';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecast: {}, loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecast) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Time</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Location</th>
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
              <td>{((forecast.time).split("T")[1]).split(".")[0]}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.location}</td>
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

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ ...this.state, forecast: data, loading: false });
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecast);
    

    return (
      <div>
        <h1 id="tabelLabel" >Current Weather</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
        <Countries/>
      </div>
    );
  }
}
