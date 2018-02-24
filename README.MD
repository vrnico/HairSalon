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

In your command line start MySql and enter the snippet below, or build an identical table in myPhpAdmin.  
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
  1. In the command line, cd into the project folder.
  2. In the command line, run dotnet restore.
  3. In the command line, type dotnet build. Enter. Any error messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
  4. In the command line, type dotnet run. Enter.

* _View program on web browser at port localhost:5000/_


```csharp

CREATE TABLE `nico_daunt`.`stylist` ( `name` VARCHAR(255) NULL DEFAULT NULL , `raw_date` VARCHAR(255) NULL DEFAULT NULL , `formatted_date` DATE NULL DEFAULT NULL , `id` INT NOT NULL AUTO_INCREMENT , PRIMARY KEY (`id`)) ENGINE = InnoDB;`

CREATE TABLE `nico_daunt`.`client` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR NULL DEFAULT NULL , `raw_appt` VARCHAR(255) NULL DEFAULT NULL , `formatted_appt` DATETIME NULL DEFAULT NULL , `stylist_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

```

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
