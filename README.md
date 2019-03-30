# CustomerRecords

A Web Api/console application that returns the name and Id of the customers within 100km of the given coordinates.

## Use

The application can be run as a Web Api 
  - CustomerRecords.WebApi  
  - API URL: https://localhost:44320/api/customerRecords

Alternatively it can be run as console application
  - CustomerRecords.Start

## Architecture

* CustomerRecords.Application 

Implement logic
  - Input file operation service
  - Great-circle distance calculation service
  - Validation helper class
  
* CustomerRecords.Domain

  - Data contract Customer
  - Data contract Position indicated the geographic coordinates 
  
* CustomerRecords.Infrastructure

Implement I/O and Deserialization
  - Input file read 
  - Input Json file deserialize to Object
  
* CustomerRecords.Start

Console application entry point
  - .Net core console application
  
* CustomerRecords.WebApi

WebAPI entry point
  - .Net core Web API

## Platform

  - .NET Core Web API 2.2 
  - .NET Standard 2.0
  -  IDE: Visual Studio 2019

## Output Result

![ApiOutput](https://user-images.githubusercontent.com/6312031/55278500-0c6e2e00-5305-11e9-83fd-a27cf24a0f9a.PNG)

![ConsoleApplicationOutput](https://user-images.githubusercontent.com/6312031/55278512-2e67b080-5305-11e9-845c-16aac90a4458.PNG)

![test](https://user-images.githubusercontent.com/6312031/55278517-34f62800-5305-11e9-854b-5326a5e8275f.PNG)

### Contact details

wuyichen1987@gmail.com
Yichen Wu
