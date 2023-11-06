# WeatherCheckApi

WeatherCheckApi is an API that allows users to check and save current weather conditions by location. It provides user authentication and weather data retrieval features.

## Endpoints

### User Authentication

#### POST `/api/login`

- **Request Body:**
  - `email` (string): The user's email address.
  - `password` (string): The user's password.

- **Response (200 OK):**
  ```json
  {
  "title": "Success",
  "status": 200,
  "message": "You are logged in successfully",
  "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIyYzQwNGMzLWQzY2MtNGRkMy1hZTJmLTI3ZmI0ODIyZWJmNSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InVzZXJAbWFpbC5jb20iLCJleHAiOjE2OTkzMDk4MTMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTIxNSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTIxNSJ9.Yv3NfvrI2F8UPm0s2oxdcofQypkrj3WtJUSUN9fDQDxPYk8kTXMpoefAplQyP-d1V1tBK5UE68z9n4X-9rQ31g"
}

- **Response (400 Bad Request):**

If the request is invalid, such as missing or invalid parameters, you will receive a 400 Bad Request response.

Response (500 Internal Server Error):

In the case of internal server errors, you will receive a 500 Internal Server Error response.

## Usage
To use this API, you can send a POST request to the /api/login endpoint with a valid email and password.
Upon successful login, you will receive a response with  a Bearer token.
Use the token for subsequent requests to authenticate the user.

#### 401 Unauthorized 
Exception will thrown if the Token was missing or invalid: 


### Using the Authentication Token

After a successful login, you will receive an authentication Bearer token. To access protected endpoints and authenticate your requests, include the token in the request header with the key "**Authorization**".

#### POST `/api/logout`
It will delete the authenticated user Token.

- **Response (204 No Content):**
  
- **Response (500 Internal Server Error):**


### Current Weather

#### GET `/api/weather/current?city=[cityname]`

The Api will fetch the current city weather from the https://www.weatherapi.com/ portal. 

- **Response (200 OK):**
  ```json
  {
    "cityName": "string",
    "temperatureC": 0,
    "windSpeedKm": 0,
    "humidity": 0,
    "requestDateTime": "2023-10-27T23:27:49.109Z"
  }


- **Response (400 Bad Request):**

If the request is invalid, such as missing or invalid parameters, you will receive a 400 Bad Request response.

- **Response (404 Not Found):**

If the requested resource is not found, you will receive a 404 Not Found response.

## Usage
To use this API, you can send a POST request to the `/api/login` endpoint with a valid email and password.

To retrieve the current weather data, you can send a GET request to the `/api/weather/current` endpoint. Upon a successful request, you will receive a response with the current weather information, including the city name, temperature in Celsius, wind speed in kilometers per hour, humidity percentage, and the date and time of the request.

In case of an error, you may receive a 400 Bad Request or 404 Not Found response.

### Save Current Weather Conditions

#### POST `/api/weather/current`


To save the current weather conditions for a specific location, you can send a POST request to the `/api/weather/current` endpoint. Upon successful creation of the weather record, you will receive a `201 Created` status response with the ID of the created weather history. In case of a failure, a `500 Internal Server Error` response will be returned.

- **Request Body:**
  ```json
  {
    "cityName": "string",
    "temperatureC": 0,
    "windSpeedKm": 0,
    "humidity": 0,
    "requestDateTime": "2023-10-27T23:40:08.777Z"
  }

- **Response (201 Created):**

    ```json
    {
    "id": 1,
    "cityName": "string",
    "temperatureC": 0,
    "windSpeedKm": 0,
    "humidity": 0,
    "requestDateTime": "2023-10-27T23:40:08.777Z"
  }

- **Response (500 Internal Server Error):**

In the case of a server error, you will receive a 500 Internal Server Error response.

### GET History of specefic City

#### GET `/api/weather/histroy?city=[cityName]`


- **Response (200 OK):**
  ```json
    [
      {
        "id": 0,
        "cityName": "string",
        "temperatureC": 0,
        "windSpeedKm": 0,
        "humidity": 0,
        "requestDateTime": "2023-10-27T23:52:21.408Z"
      },
          {
        "id": 0,
        "cityName": "string",
        "temperatureC": 0,
        "windSpeedKm": 0,
        "humidity": 0,
        "requestDateTime": "2023-10-27T23:52:21.408Z"
      }
    ]

- **Response (400 Bad Request):**

In the case of an error request, you will receive a 400 Bad Request response.


## Installation

Follow these steps to set up and run the WeatherCheckApi on your local machine:

1. **Clone the Repository:**

    ```shell
    git clone https://github.com/kingdomac/WeatherCheckApi.git
    ```

2. **Navigate to the Project Directory:**

    ```shell
    cd WeatherCheckApi
    ```

3. **Install Dependencies:**

    ```shell
    dotnet restore
    ```

3. **Migrate & Seed Database:** Open the Package manager console

    ```shell
    update-database
    ```

4. **Build the Project:**

    ```shell
    dotnet build
    ```

5. **Run the API:**

    ```shell
    dotnet run
    ```

6.  **Explore and Test:**

    You can now explore and test the API using the provided endpoints.


## Limitations

During the project, I encountered certain limitations in implementing Test-Driven Development (TDD) effectively. 
While I am well-versed in TDD practices, including unit testing, integration testing, and functional testing, 
faced challenges in some specific areas. 

One of the notable challenges was related to setting up and utilizing mocking and related functionalities.

## Project Man-Hours

I've invested a total of 10 man-hours in the development of this project.

Here's the breakdown of man-hours:

- Research & Getting Familiar with new packages [EF, Auto Mapper, Automapper dependency injection, BCrypt]: 2 hours
- Clean architecture study [Presentation, Infrastructure, Application, Domain, Utility]: 2 hours
- Development: 6 hours

**Total Man hours:** 10






