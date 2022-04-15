CREATE TABLE Candidate (
Id int IDENTITY(1,1) PRIMARY KEY,
First_Name varchar(255) not NULL,
Last_Name varchar(255) not NULL,
PhoneNumber varchar(255) not NULL,
Email varchar(255) not NULL
);
CREATE TABLE Location (
Id int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) not NULL,
Street varchar(255) not NULL,
City varchar(255) not NULL,
[State] varchar(255) not NULL,
Zip int not NULL
);
CREATE TABLE Position (
Id int IDENTITY(1,1) PRIMARY KEY,
Title varchar(255) not NULL,
Department varchar(255) not NULL,
LocationId int FOREIGN KEY REFERENCES Location(Id) ON DELETE CASCADE,
IsFullTime Bit
);
CREATE TABLE Interview (
Id int IDENTITY(1,1) PRIMARY KEY,
PositionId int FOREIGN KEY REFERENCES Position(Id) ON DELETE CASCADE,
CandidateId int FOREIGN KEY REFERENCES Candidate(Id) ON DELETE CASCADE,
StartTime DateTime not NULL,
EndTime DateTime
);

SET IDENTITY_INSERT Location ON; 
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (1, 'Jake', '1 Veterans United Drive', 'Columbia', 'MO', '65201');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (2, 'Papa', '2 Veterans United Drive', 'Columbia', 'MO', '65202');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (3, 'Sierra', '3 Veterans United Drive', 'Columbia', 'MO', '65203');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (4, 'X-Ray', '4 Veterans United Drive', 'Columbia', 'MO', '65204');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (5, 'Alpha', '5 Veterans United Drive', 'Columbia', 'MO', '65205');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (6, 'Yankee', '6 Veterans United Drive', 'Columbia', 'MO', '65205');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (7, 'Echo', '7 Veterans United Drive', 'Columbia', 'MO', '65205');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (8, 'Golf', '8 Veterans United Drive', 'Columbia', 'MO', '65205');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (9, 'Tango', '9 Veterans United Drive', 'Columbia', 'MO', '65205');
INSERT INTO [Location] (Id, Name, Street, City, [State], Zip) VALUES (10, 'Bravo', '10 Veterans United Drive', 'Columbia', 'MO', '65205');
SET IDENTITY_INSERT Location OFF;

SET IDENTITY_INSERT Position ON; 
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (1, 'Loan Officer', 'Production', '1', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (2, 'Loan Specialist', 'Production', '1', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (3, 'Loan Coordinator', 'Production', '1',1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (4, 'Software Engineer', 'Software Services', '4', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (5, 'Support Techicnian', 'Infrastucture', '2', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (6, 'Custodian', 'Facilities', '3', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (7, 'Maintenance', 'Facilities', '3', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (8, 'HR Business Partner', 'Human Resources', '5', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (9, 'Recruiter', 'Human Resources', '5', 1);
INSERT INTO Position (Id, Title, Department, LocationId, IsFullTime) VALUES (10, 'Underwriter', 'Production', '1', 1);
SET IDENTITY_INSERT Position OFF;

SET IDENTITY_INSERT Candidate ON; 
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (1, 'Ross', 'Henke', '8675309', 'Rossemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (2, 'John', 'Galloway', '2345678', 'Johnemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (3, 'Brandon', 'Gunther', '2345679', 'Brandonemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (4, 'Bob', 'Ross', '2345670', 'Bobemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (5, 'Tom', 'Smith', '2345673', 'Tomemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (6, 'Jill', 'Songer', '2345673', 'Tomemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (7, 'Thomas', 'Wraith', '2345673', 'Tomemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (8, 'Tyler', 'Jennings', '2345673', 'Tomemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (9, 'Jean-Luc', 'Picard', '2345673', 'Tomemail@vu.com');
INSERT INTO Candidate (Id, First_Name, Last_Name, PhoneNumber, Email) VALUES (10, 'Steve', 'Austin', '2345673', 'Tomemail@vu.com');
SET IDENTITY_INSERT Candidate OFF;

SET IDENTITY_INSERT Interview ON; 
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (1, 1, 1, '20220330 10:30 AM', '20220330 11:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (2, 2, 1, '20220330 10:30 AM', '20220330 11:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (3, 1, 2,'20220331 8:00 AM', '20220331 9:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (4, 3, 2,'20220331 8:00 AM', '20220331 9:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (5, 2, 3,'20220401 1:00 PM', '20220401 2:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (6, 1, 3,'20220401 1:00 PM', '20220401 2:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (7, 2, 4,'20220329 12:00 PM', '20220329 1:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (8, 4, 4,'20220329 12:00 PM', '20220329 1:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (9, 3, 5,'20220327 7:00 AM', '20220327 8:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (10, 5, 5,'20220327 7:00 AM', '20220327 8:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (11, 10, 6, '20220330 10:30 AM', '20220330 11:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (12, 9, 6, '20220330 10:30 AM', '20220330 11:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (13, 10, 7,'20220331 8:00 AM', '20220331 9:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (14, 8, 7,'20220331 8:00 AM', '20220331 9:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (15, 9, 8,'20220401 1:00 PM', '20220401 2:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (16, 8, 8,'20220401 1:00 PM', '20220401 2:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (17, 7, 9,'20220329 12:00 PM', '20220329 1:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (18, 6, 9,'20220329 12:00 PM', '20220329 1:00 PM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (19, 6, 10,'20220327 7:00 AM', '20220327 8:00 AM');
INSERT INTO Interview (Id, PositionId, CandidateId, StartTime, EndTime) VALUES (20, 7, 10,'20220327 7:00 AM', '20220327 8:00 AM');
SET IDENTITY_INSERT Interview OFF;