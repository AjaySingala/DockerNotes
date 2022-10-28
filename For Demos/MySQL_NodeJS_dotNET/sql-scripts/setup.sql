CREATE TABLE `super-app`.`User` (
  `Id` INT NOT NULL,
  `Firstname` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`));

CREATE TABLE `super-app`.`Job` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  `UserId` INT NULL,
  PRIMARY KEY (`Id`));
