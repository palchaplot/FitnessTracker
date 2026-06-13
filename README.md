# Fitness Tracker API

## Overview

Fitness Tracker API is a RESTful backend application built using ASP.NET Core Web API. It allows users to register, log in securely, manage workouts, and track fitness activities using JWT authentication and authorization.

## Features

### Authentication

* User Registration
* User Login
* JWT Authentication
* JWT Authorization
* BCrypt Password Hashing

### Workout Management

* Create Workout
* Get Workouts
* Get Workout By Id
* Update Workout
* Delete Workout
* User-specific workout filtering

## Architecture

The project follows a layered architecture:

Controller → Service → Repository → Database

### Layers

#### Controllers

Handle HTTP requests and responses.

#### Services

Contain business logic.

#### Repositories

Handle database operations using Entity Framework Core.

#### Database

SQL Server with Entity Framework Core.

## Technologies Used

* ASP.NET Core 8 Web API
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt Password Hashing
* Swagger UI
* Git & GitHub

## API Endpoints

### Authentication

POST /api/Auth/register

POST /api/Auth/login

### Workouts

GET /api/Workout

GET /api/Workout/{id}

POST /api/Workout

PUT /api/Workout/{id}

DELETE /api/Workout/{id}

## Security

* JWT Token Based Authentication
* Password Hashing using BCrypt
* Protected Endpoints using Authorize Attribute

## Future Enhancements

* Goal Tracking Module
* User Profile Management
* Fitness Analytics
* AI-Based Workout Recommendations
* Angular Frontend Integration

## Author

Pal
