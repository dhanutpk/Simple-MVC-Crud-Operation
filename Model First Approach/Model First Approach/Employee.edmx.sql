
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2015 17:42:24
-- Generated from EDMX file: d:\users\djogihal\documents\visual studio 2012\Projects\Model First Approach\Model First Approach\Employee.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestEmployee];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_EmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeAddresses] DROP CONSTRAINT [FK_Address];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[EmployeeAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeAddresses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(250)  NOT NULL,
    [LastName] nvarchar(250)  NOT NULL,
    [DOB] datetime  NULL,
    [DOJ] datetime  NULL,
    [EmailId] nvarchar(200)  NULL,
    [DeptId] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DeptId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(250)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'EmployeeAddresses'
CREATE TABLE [dbo].[EmployeeAddresses] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [AddressLine1] nvarchar(250)  NULL,
    [AddressLine2] nvarchar(250)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [DeptId] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DeptId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'EmployeeAddresses'
ALTER TABLE [dbo].[EmployeeAddresses]
ADD CONSTRAINT [PK_EmployeeAddresses]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DeptId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeDepartment]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Departments]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeDepartment'
CREATE INDEX [IX_FK_EmployeeDepartment]
ON [dbo].[Employees]
    ([DeptId]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeAddresses'
ALTER TABLE [dbo].[EmployeeAddresses]
ADD CONSTRAINT [FK_Address]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------