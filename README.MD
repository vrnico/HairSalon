

'''

CREATE TABLE `nico_daunt`.`stylist` ( `name` VARCHAR(255) NULL DEFAULT NULL , `raw_date` VARCHAR(255) NULL DEFAULT NULL , `formatted_date` DATE NULL DEFAULT NULL , `id` INT NOT NULL AUTO_INCREMENT , PRIMARY KEY (`id`)) ENGINE = InnoDB;`

CREATE TABLE `nico_daunt`.`client` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR NULL DEFAULT NULL , `raw_appt` VARCHAR(255) NULL DEFAULT NULL , `formatted_appt` DATETIME NULL DEFAULT NULL , `stylist_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

'''
