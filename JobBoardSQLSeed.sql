<<<<<<< HEAD
--CREATE TABLE Candidate (
--Id int IDENTITY(1,1) PRIMARY KEY,
--[Name] varchar(255) not NULL,
--PhoneNumber varchar(255) not NULL,
--Email varchar(255) not NULL
--);
--CREATE TABLE Location (
--Id int IDENTITY(1,1) PRIMARY KEY,
--LocationName varchar(255) not NULL,
--StreetAddress varchar(255) not NULL,
--City varchar(255) not NULL,
--[State] varchar(255) not NULL,
--Zip int not NULL
--);
--CREATE TABLE Position (
--Id int IDENTITY(1,1) PRIMARY KEY,
--Title varchar(255) not NULL,
--[Description] varchar(255) not NULL,
--LocationId int FOREIGN KEY REFERENCES Location(Id) ON UPDATE CASCADE,
--IsFullTime Bit
--);
--CREATE TABLE Interview (
--Id int IDENTITY(1,1) PRIMARY KEY,
--PositionId int FOREIGN KEY REFERENCES Position(Id),
--LocationId int FOREIGN KEY REFERENCES Location(Id),
--CandidateId int FOREIGN KEY REFERENCES Candidate(Id),
--StartTime DateTime not NULL,
--EndTime DateTime
--);

--SET IDENTITY_INSERT Location ON; 
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (1, 'Jake', '1 Veterans United Drive', 'Columbia', 'MO', '65201');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (2, 'Papa', '2 Veterans United Drive', 'Columbia', 'MO', '65202');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (3, 'Sierra', '3 Veterans United Drive', 'Columbia', 'MO', '65203');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (4, 'X-Ray', '4 Veterans United Drive', 'Columbia', 'MO', '65204');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (5, 'Alpha', '5 Veterans United Drive', 'Columbia', 'MO', '65205');
--SET IDENTITY_INSERT Location OFF;

--SET IDENTITY_INSERT Position ON; 
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (1, 'Loan Officer', 'Production', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (2, 'Loan Specialist', 'Production', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (3, 'Loan Coordinator', 'Production', '1',1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (4, 'Software Engineer', 'Software Services', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (5, 'Closing Specialist', 'Production', '2', 1);
--SET IDENTITY_INSERT Position OFF;

--SET IDENTITY_INSERT Candidate ON; 
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (1, 'Ross Henke', '8675309', 'Rossemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (2, 'John Galloway', '2345678', 'Johnemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (3, 'Brandon Gunther', '2345679', 'Brandonemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (4, 'Bob Ross', '2345670', 'Bobemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (5, 'Tom', '2345673', 'Tomemail@vu.com');
--SET IDENTITY_INSERT Candidate OFF;

--SET IDENTITY_INSERT Interview ON; 
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (1, 1, 1, 3, '20220330 10:30 AM', '20220330 11:00 AM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (2, 1, 2, 2,'20220331 8:00 AM', '20220331 9:00 AM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (3, 2, 4, 4,'20220401 1:00 PM', '20220401 2:00 PM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (4, 2, 5, 1,'20220329 12:00 PM', '20220329 1:00 PM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime)VALUES (5, 3, 3, 5,'20220327 7:00 AM', '20220327 8:00 AM');
--SET IDENTITY_INSERT Interview OFF;


=======
--CREATE TABLE Candidate (
--Id int IDENTITY(1,1) PRIMARY KEY,
--[Name] varchar(255) not NULL,
--PhoneNumber varchar(255) not NULL,
--Email varchar(255) not NULL
--);
--CREATE TABLE Location (
--Id int IDENTITY(1,1) PRIMARY KEY,
--LocationName varchar(255) not NULL,
--StreetAddress varchar(255) not NULL,
--City varchar(255) not NULL,
--[State] varchar(255) not NULL,
--Zip int not NULL
--);
--CREATE TABLE Position (
--Id int IDENTITY(1,1) PRIMARY KEY,
--Title varchar(255) not NULL,
--[Description] varchar(255) not NULL,
--LocationId int FOREIGN KEY REFERENCES Location(Id) ON UPDATE CASCADE,
--IsFullTime Bit
--);
--CREATE TABLE Interview (
--Id int IDENTITY(1,1) PRIMARY KEY,
--PositionId int FOREIGN KEY REFERENCES Position(Id),
--LocationId int FOREIGN KEY REFERENCES Location(Id),
--CandidateId int FOREIGN KEY REFERENCES Candidate(Id),
--StartTime DateTime not NULL,
--EndTime DateTime
--);

--SET IDENTITY_INSERT Location ON; 
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (1, 'Jake', '1 Veterans United Drive', 'Columbia', 'MO', '65201');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (2, 'Papa', '2 Veterans United Drive', 'Columbia', 'MO', '65202');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (3, 'Sierra', '3 Veterans United Drive', 'Columbia', 'MO', '65203');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (4, 'X-Ray', '4 Veterans United Drive', 'Columbia', 'MO', '65204');
--INSERT INTO [Location] (Id, LocationName, StreetAddress, City, [State], Zip) VALUES (5, 'Alpha', '5 Veterans United Drive', 'Columbia', 'MO', '65205');
--SET IDENTITY_INSERT Location OFF;

--SET IDENTITY_INSERT Position ON; 
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (1, 'Loan Officer', 'Production', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (2, 'Loan Specialist', 'Production', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (3, 'Loan Coordinator', 'Production', '1',1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (4, 'Software Engineer', 'Software Services', '1', 1);
--INSERT INTO Position (Id, Title, [Description], LocationId, IsFullTime) VALUES (5, 'Closing Specialist', 'Production', '2', 1);
--SET IDENTITY_INSERT Position OFF;

--SET IDENTITY_INSERT Candidate ON; 
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (1, 'Ross Henke', '8675309', 'Rossemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (2, 'John Galloway', '2345678', 'Johnemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (3, 'Brandon Gunther', '2345679', 'Brandonemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (4, 'Bob Ross', '2345670', 'Bobemail@vu.com');
--INSERT INTO Candidate (Id, [Name], PhoneNumber, Email) VALUES (5, 'Tom', '2345673', 'Tomemail@vu.com');
--SET IDENTITY_INSERT Candidate OFF;

--SET IDENTITY_INSERT Interview ON; 
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (1, 1, 1, 3, '20220330 10:30 AM', '20220330 11:00 AM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (2, 1, 2, 2,'20220331 8:00 AM', '20220331 9:00 AM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (3, 2, 4, 4,'20220401 1:00 PM', '20220401 2:00 PM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime) VALUES (4, 2, 5, 1,'20220329 12:00 PM', '20220329 1:00 PM');
--INSERT INTO Interview (Id, PositionId, LocationId, CandidateId, StartTime, EndTime)VALUES (5, 3, 3, 5,'20220327 7:00 AM', '20220327 8:00 AM');
--SET IDENTITY_INSERT Interview OFF;


>>>>>>> d3e7bf2586cd58ccbffe884663f27f389302b0ad
