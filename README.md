# Sales order data managment
Task description: [Pref Test Task.pdf](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/files/13793700/Pref.Test.Task.pdf)

## Table of contents
1. [Installation and Launch Instructions](#installation-and-launch-instructions)
2. [Application architecture](#application-architecture)

## Installation and Launch Instructions

To get started with the application, follow these steps:

1. **Clone the Repository**: 
   Begin by cloning the repository to your local machine.

2. **Run the Setup Script**:
   - Execute the `startup.bat` file located in the root directory.
   - This script will automatically build and launch both the Blazor WebAssembly and Web API applications.
   - By default, the applications will run on the following local ports:
     - Blazor WebAssembly: `localhost:5001`
     - Web API: `localhost:5000`

3. **Database Setup**:
   - The application uses MSSQL as its database.
   - You have two options for setting up MSSQL:
     - **Local Installation**: Ensure MSSQL is installed on your device.
     - **Docker**: Alternatively, you can run MSSQL in a Docker container.
   - Upon the first launch of the application, a new database complete with test data will be automatically created.

Please ensure that MSSQL or Docker is properly set up and running before launching the application to avoid any connection issues.

## Application Architecture
The application is designed in accordance with a multi-layer (three-layer) architecture:

![image](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/assets/147520809/1d15bc9e-9b88-436c-bec5-a38b58f26d02)

* [Data Access Layer (DAL)](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.DAL)
* [Business Logic Layer (BLL)](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL)
* [Presentation Layer aka UI](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.Client)


### Data Access Layer (DAL)

This layer provides access to data stored in the database. Technology **Entity Framework**, **Repository** and **Unit of work** pattern are used to interact with objects.

Contains:
* [Context](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.DAL/Context)
* [Entities](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.DAL/Entities)
* [Interfaces for Repository pattern](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.DAL/Interfaces)
* [Repositories realisations](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.DAL/Repositories) for each entity

### Business Logic Layer (BLL)

The presentation layer works with the data stored in the database not directly, but through the **Business Logic Layer**.

Here, through the **services**, the database entities are converted to **Data Transfer Object (DTO)** and provided for further interaction with the user to the **Presentation Layer** layer.

Contains:
* [DTO](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL/DTO)
* [Interfaces for Services](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL/Interfaces)
* [Services realisations](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL/Services)
* [Mappers](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL/Mappers) for mapping using `AutoMapper` libary
* [Extension](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.BLL/Extensions)


### Presentation Layer (aka UI)

Direct user interaction layer. Made with technology Blazor WebAssembly (hosted on ASP.NET Core).

The **Server** side of the application contains [API Controllers](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.Server/Controllers). 

The **Client** part contains:
1. [Pages](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.Client/Pages) - to display information to the user and interact with the website
2. [Dialogs](https://github.com/OleksandrLeskiv/OrderManagmentTestTask/tree/master/SalesOrderDataManager.Client/Dialogs) - to work with creating and editing objects
