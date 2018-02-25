# Hair Salon

#### .Net MVC app that allows user to manage employees, clients, hire dates, and appointment.

#### _By Nico Daunt_

## Description

_This is the Epicodus code review project for week 3 of the C# course. Its purpose is to display understanding of Database Basics in C# and MySql._


___
### Specifications

* User creates a Stylist profile

  * Input: "Madame Madman"
  * Output: "name: Madame Madman"

* User adds Stylist details

  * Input: "Madame Madman" "2/23/2018"
  * Output:"name: Madame Madman" "hired on: February 23, 2018"

* User creates client

  * Input: "Potato Fran"
  * Output: "name: Potato Fran"

* User assigns client to Stylist

  * Input: "Potato Fran" to "Madame Madman"
  * Output: "Stylist: Madame Madman, Client: Potato Fran"

* User can set appointments for Client and view from within Stylist profile

  * Input: "Potato Fran" "2/25/2018"
  * Output: "Appointment with Potato Fran on 2/25/2018"



## Setup/Installation Requirements

*  _Setup assumes prior installation of the .NET Framework and MAMP_
  *  .NET Core 1.1 SDK (Software Development Kit)
  *  .NET runtime.
  *  MAMP, LAMP, or XAMP


*  git clone https://github.com/vrnico/HairSalon.git


*    _Create Database_

In your command line start MySql and enter the snippet below, or build an identical database in myPhpAdmin.

* setup assumes mySql is using port 8889, if you are trying to use another port, make sure to change the port number in Models/Database.cs and .csproj files.

```csharp

CREATE TABLE `clients` (
  `name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `raw_appt` varchar(19) DEFAULT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `stylists` (
  `name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


```

* _Start the MySql Server in MAMP_

* _Run the program_
1. In the command line, cd into the project folder /HairSalon/HairSalon.
2. In the command line, run dotnet restore.
  * Repeat step for HairSalon/HairSalon.test in order to set up testing environment if necessary.
3. In the command line, type dotnet build. Any error messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When build succeeds, proceed to the next step.
4. In the command line, type dotnet run. Enter.

* _View program on web browser at port localhost:5000/_

* Go nuts adding stylists, clients, and appointment dates!

![](https://i.gyazo.com/c771e50b7f46bf6fa950d098b7428a82.gif)



## Technologies Used

* HTML
* Bootstrap
* C#
* MAMP
* .Net Core 1.1
* Razor
* MySQL

### License

*MIT License*

Copyright (c) 2018 **_Nico Daunt_**
