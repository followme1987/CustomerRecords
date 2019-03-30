# CustomerRecords

A Web Api/console application that returns the name and Id of the customers within 100km of Intercom Dublin office.

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
  
### Contact details

wuyichen1987@gmail.com
Yichen Wu
