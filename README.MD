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





```csharp

CREATE TABLE `nico_daunt`.`stylist` ( `name` VARCHAR(255) NULL DEFAULT NULL , `raw_date` VARCHAR(255) NULL DEFAULT NULL , `formatted_date` DATE NULL DEFAULT NULL , `id` INT NOT NULL AUTO_INCREMENT , PRIMARY KEY (`id`)) ENGINE = InnoDB;`

CREATE TABLE `nico_daunt`.`client` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR NULL DEFAULT NULL , `raw_appt` VARCHAR(255) NULL DEFAULT NULL , `formatted_appt` DATETIME NULL DEFAULT NULL , `stylist_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

```
