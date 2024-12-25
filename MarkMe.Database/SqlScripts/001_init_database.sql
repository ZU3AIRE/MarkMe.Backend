IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MarkMe')
BEGIN
    CREATE DATABASE MarkMe;
END
GO

USE MarkMe;
GO

-- Create Users table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY IDENTITY(1, 1),
        Username VARCHAR(50) NOT NULL UNIQUE,
        Email VARCHAR(100) NOT NULL UNIQUE,
        CreatedAt DATETIME DEFAULT GETDATE(),
        UpdatedAt DATETIME,
        UpdatedBy INT NULL,
        IsActive BIT DEFAULT 1
    );
END;

-- Create Courses table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Courses')
BEGIN
    CREATE TABLE Courses (
        CourseId INT PRIMARY KEY IDENTITY(1,1),
        Code NVARCHAR(10) NOT NULL,
        Title NVARCHAR(100) NOT NULL,
        Type INT NOT NULL,
        Semester INT NOT NULL,
        AssignedTo INT NOT NULL REFERENCES Users(UserId),
        CreditHours INT NOT NULL,
        IsArchived BIT NOT NULL DEFAULT(0)
    );
END
GO

-- Create Students table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
BEGIN
    CREATE TABLE Students (
        StudentId INT PRIMARY KEY IDENTITY(1, 1),
        CollegeRollNo NVARCHAR(4) NOT NULL,
        UniversityRollNo NVARCHAR(10) NOT NULL,
        RegistrationNo NVARCHAR(15) NOT NULL,
        FirstName VARCHAR(50) NOT NULL,
        LastName VARCHAR(50) NOT NULL,
        Session NVARCHAR(9) NOT NULL,
        Section NVARCHAR(20) NOT NULL,
        IsDeleted BIT NOT NULL DEFAULT(0)
    );
END
GO

-- Create Attendance table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Attendance')
BEGIN
    CREATE TABLE Attendance (
        AttendanceId INT PRIMARY KEY IDENTITY(1, 1),
        StudentId INT NOT NULL REFERENCES Students(StudentId),
        CourseId INT NOT NULL REFERENCES Courses(CourseId),
        DateMarked DATETIME DEFAULT GETDATE(),
        MarkedBy INT NOT NULL REFERENCES Users(UserId),
    );
END
GO

-- Create ClassRepresentatives table if not exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ClassRepresentatives')
BEGIN
    CREATE TABLE ClassRepresentatives (
        ClassRepresentativeId INT NOT NULL IDENTITY(1, 1),
        StudentId INT NOT NULL REFERENCES Students(StudentId),
        CourseId INT NOT NULL REFERENCES Courses(CourseId),
        NominatedBy INT NOT NULL REFERENCES Users(UserId),
        IsDeleted BIT NOT NULL DEFAULT(0)
    );
END
GO

-- Insert into Students table
IF NOT EXISTS (SELECT 1 FROM [dbo].[Students] WHERE CollegeRollNo = 537)
BEGIN
    INSERT INTO [dbo].[Students]
           ([CollegeRollNo]
           ,[UniversityRollNo]
           ,[RegistrationNo]
           ,[FirstName]
           ,[LastName]
           ,[Session]
           ,[Section]
           ,[IsDeleted])
     VALUES
           (537, '070940', '2021-gsr-439', 'Zubair', 'Jamil', '2021-2025', 'G1', 0);
END;

IF NOT EXISTS (SELECT 1 FROM [dbo].[Students] WHERE CollegeRollNo = 501)
BEGIN
    INSERT INTO [dbo].[Students]
           ([CollegeRollNo]
           ,[UniversityRollNo]
           ,[RegistrationNo]
           ,[FirstName]
           ,[LastName]
           ,[Session]
           ,[Section]
           ,[IsDeleted])
     VALUES
           (501, '070936', '2021-gsr-451', 'Mousa', 'Naeem', '2021-2025', 'G1', 0);
END;

IF NOT EXISTS (SELECT 1 FROM [dbo].[Students] WHERE CollegeRollNo = 517)
BEGIN
    INSERT INTO [dbo].[Students]
           ([CollegeRollNo]
           ,[UniversityRollNo]
           ,[RegistrationNo]
           ,[FirstName]
           ,[LastName]
           ,[Session]
           ,[Section]
           ,[IsDeleted])
     VALUES
           (517, '070955', '2021-gsr-414', 'Aftab', 'Sattar', '2021-2025', 'G1', 0);
END;

-- Insert into Users table
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'zubairjamil12')
BEGIN
    INSERT INTO [dbo].[Users]
           ([Username]
           ,[Email]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('zubairjamil12', 'zestyxee@gmail.com', GETDATE(), NULL, NULL, 1);
END;

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'mousanaeem12')
BEGIN
    INSERT INTO [dbo].[Users]
           ([Username]
           ,[Email]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('mousanaeem12', 'mousa.naeem@gmail.com', GETDATE(), NULL, NULL, 1);
END;

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'aftabsattar@91')
BEGIN
    INSERT INTO [dbo].[Users]
           ([Username]
           ,[Email]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('aftabsattar@91', 'aftab.sattar@gmail.com', GETDATE(), NULL, NULL, 1);
END;
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'zsabir@11')
BEGIN
    INSERT INTO [dbo].[Users]
           ([Username]
           ,[Email]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('zsabir@11', 'zsabir@gmail.com', GETDATE(), NULL, NULL, 1);
END;
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'narif@11')
BEGIN
    INSERT INTO [dbo].[Users]
           ([Username]
           ,[Email]
           ,[CreatedAt]
           ,[UpdatedAt]
           ,[UpdatedBy]
           ,[IsActive])
     VALUES
           ('narif@11', 'narif@gmail.com', GETDATE(), NULL, NULL, 1);
END;
GO
