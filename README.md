# task2

## Requirements

1. .NET Core 3.1
2. Node.js (for NPM)

## Building and Running

There are several steps:
1. Restore all packages dependencies for our Web API
> dotnet restore ./XtramileSolutionTest/
2. Building and running our Web API can be done using one command
> dotnet run ./XtramileSolutionTest/
3. Install react modules for our web user interface
> npm install --legacy-peer-deps ./XtramileSolutionTest/WeatherApp/ClientApp/
4. Run the UI
> npm start ./XtramileSolutionTest/WeatherApp/ClientApp/
5. For Unit testing (optional):
> dotnet test ./XtramileSolutionTest/
