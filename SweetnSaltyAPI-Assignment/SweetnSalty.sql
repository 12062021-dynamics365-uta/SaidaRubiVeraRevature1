CREATE DATABASE SweetnSalty;

CREATE TABLE Persons(
PersonId INT PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL);

CREATE TABLE Flavors(
FlavorId INT PRIMARY KEY IDENTITY(1,1),
Flaver nvarchar(50) NOT NULL);

CREATE TABLE PersonFlavorJunction
(PersonId INT NOT NULL FOREIGN KEY REFERENCES Persons(PersonId),
FlavorId INT NOT NULL FOREIGN KEY REFERENCES Flavors(FlavorId));