USE CRS

-- Add Tables
CREATE TABLE Roles (
	RoleId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	RoleName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE Users (
	UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Username VARCHAR(255) NOT NULL,
	Password VARCHAR(255) NOT NULL,
	RoleId INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleId)
)

--ALTER TABLE Users
--ADD CONSTRAINT FK_Users_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)

CREATE TABLE Majors (
	MajorId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MajorName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE Departments (
	DepartmentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DepartmentName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE Courses (
	CourseId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CourseName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE RegistrationStatus (
	RegistrationStatusId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	RegistrationStatusName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE Students(
	StudentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StudentName VARCHAR(255) NOT NULL,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
	MajorId INT NOT NULL FOREIGN KEY REFERENCES Majors(MajorId),
	Email VARCHAR(255) NOT NULL,
	Phone VARCHAR(255) NOT NULL,
	Address VARCHAR(255) NOT NULL,
)

CREATE TABLE Admin(
	AdminId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	AdminName VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Phone VARCHAR(255) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Professors(
	ProfessorId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ProfessorName VARCHAR(255) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(DepartmentId),
	Email VARCHAR(255) NOT NULL,
	Phone VARCHAR(255) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE SemesterRegistration(
	RegistrationId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId),
	ApprovalStatus INT NOT NULL,
	AdminId INT NOT NULL FOREIGN KEY REFERENCES Admin(AdminId),
	Comment VARCHAR(255) NOT NULL
)

CREATE TABLE RegisteredCourses(
	RegisteredCourseId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId),
	CourseId INT NOT NULL FOREIGN KEY REFERENCES Courses(CourseId),
	RegistrationStatusId INT NOT NULL FOREIGN KEY REFERENCES RegistrationStatus(RegistrationStatusId),
	Grade VARCHAR(3),
	UUID VARCHAR(255),
	CreateDateTime DATETIME
)

CREATE TABLE ProfessorCourses (
	ProfessorCoursesId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ProfessorId INT NOT NULL FOREIGN KEY REFERENCES Professors(ProfessorId),
	CourseId INT NOT NULL FOREIGN KEY REFERENCES Courses(CourseId),
	UUID VARCHAR(255),
	CreateDateTime DATETIME
)

CREATE TABLE PaymentMethods (
	PaymentMethodId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PaymentMethodName VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL
)

CREATE TABLE Payment (
	PaymentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PaymentAmount DECIMAL,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId),
	DueDate DATETIME NOT NULL,
	Semester VARCHAR(255) NOT NULL,
	PaymentMethodId INT,
	IsPaid BIT
)

CREATE TABLE CourseCatalog (
	CourseCatalogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CourseId INT NOT NULL FOREIGN KEY REFERENCES Courses(CourseId),
	ProfessorId INT NOT NULL FOREIGN KEY REFERENCES Professors(ProfessorId),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(DepartmentId),
	Prerequisite VARCHAR(255),
	Credits INT NOT NULL,
	Capacity INT NOT NULL,
	Enrolled INT,
	Semester VARCHAR(255) NOT NULL,
	CourseCatalogItemGuid VARCHAR(255),
	CreateDateTime DATETIME
)

-- Add Init. Data
INSERT INTO Roles
(RoleName, Description)
VALUES
('admin', 'Administrator'),
('professor', 'Staff'),
('student', 'Student')

INSERT INTO Users 
(UserName, Password, RoleId)
VALUES
('admin', 'admin', 1),
('tparker','tiger123',3),
('amalik','shoes123',3),
('twatkins','ocean123',3),
('rwu','mountain123',2),
('aortega','landscape123',2),
('nmorrison','fountain123',2),
('cjohnson','grass123',2),
('wWonka','fire123',2)

INSERT INTO Majors
(MajorName, Description)
VALUES
('Biology', 'Science'),
('Psychology', 'Science'),
('Economics', 'Science'),
('Mathematics', 'Science'),
('Physics', 'Science'),
('Communications', 'Art'),
('Literature', 'Art'),
('English', 'Art'),
('Dance', 'Art'),
('Fashion', 'Art'),
('Architecture', 'Engineering'),
('Engineering', 'Engineering'),
('Computer Science', 'Engineering')

INSERT INTO Departments
(DepartmentName, Description)
VALUES
('Biology Department', 'BIO'),
('Psychology Department', 'PSYCH'),
('Business Department', 'BUS'),
('Mathematics & Physics Department', 'MATHPHYS'),
('Communications Department', 'COMM'),
('English Department', 'ENGL'),
('Art Department', 'ART'),
('Engineering Department', 'ENGI'),
('Computer Science Department', 'COMSCI')

INSERT INTO PaymentMethods 
(PaymentMethodName, Description)
VALUES
('Credit', 'Credit Card'),
('Debit', 'Debit Card'),
('Cash', 'Effective'),
('Scholarship', 'Award'),
('Financial Aid', 'Benefit'),
('Direct Deposit', 'Bank Withdrawal'),
('Wire Transfer', 'Wire')

INSERT INTO Courses
(CourseName, Description)
VALUES
('Biology 1', 'BIO-1'),
('Biology 2', 'BIO-2'),
('Biology 3', 'BIO-3'),
('Psychology 1', 'PSYCH-1'),
('Psychology 2', 'PSYCH-2'),
('Psychology 3', 'PSYCH-3'),
('Economics 1', 'ECON-1'),
('Economics 2', 'ECON-2'),
('Economics 3', 'ECON-3'),
('Calculus 1', 'CALC-1'),
('Calculus 2', 'CALC-2'),
('Calculus 3', 'CALC-3'),
('Literature 1', 'LIT-1'),
('Literature 2', 'LIT-2'),
('Literature 3', 'LIT-3'),
('Dance 1', 'DAN-1'),
('Dance 2', 'DAN-2'),
('Dance 3', 'DAN-3')

INSERT INTO Students 
(StudentName, UserId, MajorId, Email, Phone, Address)
VALUES
('Thomas Parker',1,13,'tparker@test.com','111-222-3333','Parker Ave, NY'),
('Abigail Malik',2,14,'amalik@test.com','111-222-3333','Abigail Ln, NJ'),
('Tej Watkins',3,15,'twatkins@test.com','111-222-3333','Tej Rd, CT')

ALTER TABLE Professors
ADD UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId)

INSERT INTO Professors 
(ProfessorName, DepartmentId, Email, Phone, Address, UserId)
VALUES
('Rubin Wu',1,'rwur@test.com','111-222-3333','Rubin Ave, NY',5),
('Axel Ortega',2,'aortega@test.com','111-222-3333','Axel Ln, NJ',6),
('Nelson Morrison',3,'nmorrison@test.com','111-222-3333','Nelson Rd, CT',7),
('Charlie Johnson',4,'cjohnson@test.com','111-222-3333','40 Jonhnson Cr',8),
('Willy Wonka',5,'wWonka@test.com','111-222-3333','1272 Wonka Rd',9)

ALTER TABLE Admin
ADD UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId)

INSERT INTO Admin 
(AdminName, Email, Phone, Address, UserId)
VALUES
('admin','admin@test.com','111-222-3333','100 Test Ave.',1)

INSERT INTO CourseCatalog
(CourseId, ProfessorId, DepartmentId, Prerequisite, Credits, Capacity, Enrolled, Semester, UUID, CreateDateTime)
VALUES
(1, 1, 1, NULL, 3, 100, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(2, 1, 1, 'BIO-1', 3, 75, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(3, 1, 1, 'BIO-2', 3, 50, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(4, 2, 2, NULL, 3, 100, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(5, 2, 2, 'PSYCH-1', 3, 75, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(6, 2, 2, 'PSYCH-2', 3, 50, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(7, 3, 3, NULL, 3, 100, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(8, 3, 3, 'ECON-1', 3, 75, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(9, 3, 3, 'ECON-2', 3, 50, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(10, 4, 4, NULL, 3, 100, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(11, 4, 4, 'CALC-1', 3, 75, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE()),
(12, 4, 4, 'CALC-2', 3, 50, 0, 'Spring 2023', CONVERT(VARCHAR(255), NEWID()), GETDATE())
GO

CREATE SCHEMA Monitoring;
GO

CREATE TABLE Monitoring.ApiServiceLogs (
	LogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Message VARCHAR(255) NOT NULL,
	Status VARCHAR(255) NOT NULL,
	CreateDateTime DATETIME NOT NULL
)

CREATE TABLE Monitoring.DatabaseLogs (
	LogId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Message VARCHAR(255) NOT NULL,
	Status VARCHAR(255) NOT NULL,
	CreateDateTime DATETIME NOT NULL
)

-- Store Procedures
