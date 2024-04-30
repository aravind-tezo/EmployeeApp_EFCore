create schema ConsoleApp;


CREATE TABLE ConsoleApp.Roles (
  Id VARCHAR(255) NOT NULL PRIMARY KEY,
  Name VARCHAR(255) NOT NULL,
  Department VARCHAR(255),
  Description TEXT, -- Assuming a larger text description
  Location VARCHAR(255)
);

CREATE TABLE ConsoleApp.Employees (
  Id VARCHAR(255) NOT NULL PRIMARY KEY,
  FirstName VARCHAR(255) NOT NULL,
  LastName VARCHAR(255) NOT NULL,
  DateOfBirth DATE,
  EmailId VARCHAR(255) UNIQUE,
  MobileNo VARCHAR(20),
  DateOfJoining DATE,
  RoleId VARCHAR(255),
  ProjectName VARCHAR(255),
  Location VARCHAR(255),
  Department VARCHAR(255),
  ManagerName VARCHAR(255),
  FOREIGN KEY (RoleId) REFERENCES ConsoleApp.Roles(Id)
);

drop table ConsoleApp.Employees;
drop table ConsoleApp.Roles;

select * from ConsoleApp.Employees;
select * from ConsoleApp.Roles;