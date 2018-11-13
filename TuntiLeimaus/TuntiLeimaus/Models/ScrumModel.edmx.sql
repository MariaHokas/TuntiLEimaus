
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2018 18:41:04
-- Generated from EDMX file: C:\Users\Käyttäjä\Source\Repos\TuntiLeimaus4\TuntiLeimaus\TuntiLeimaus\Models\ScrumModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TuntiLeimaus];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Luokkahuone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Leimaus] DROP CONSTRAINT [FK_Luokkahuone];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Leimaus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leimaus];
GO
IF OBJECT_ID(N'[dbo].[Luokkahuone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Luokkahuone];
GO
IF OBJECT_ID(N'[dbo].[Opettajat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opettajat];
GO
IF OBJECT_ID(N'[dbo].[Opiskelijat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opiskelijat];
GO
IF OBJECT_ID(N'[dbo].[Tuntiraportti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tuntiraportti];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Leimaus'
CREATE TABLE [dbo].[Leimaus] (
    [OpiskelijaID] int IDENTITY(1,1) NOT NULL,
    [LuokkahuoneID] int  NULL,
    [Sisään] datetime  NULL,
    [Ulos] datetime  NULL
);
GO

-- Creating table 'Luokkahuone'
CREATE TABLE [dbo].[Luokkahuone] (
    [LuokkahuoneID] int  NOT NULL,
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL
);
GO

-- Creating table 'Opettajat'
CREATE TABLE [dbo].[Opettajat] (
    [OpettajaID] int  NOT NULL,
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL
);
GO

-- Creating table 'Opiskelijat'
CREATE TABLE [dbo].[Opiskelijat] (
    [OpiskelijaID] int  NOT NULL,
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL
);
GO

-- Creating table 'Tuntiraportti'
CREATE TABLE [dbo].[Tuntiraportti] (
    [OpiskelijaID] int  NOT NULL,
    [Etunimi] varchar(50)  NULL,
    [Sukunimi] varchar(50)  NULL,
    [LuokkahuoneID] int  NULL,
    [Sisään] datetime  NULL,
    [Ulos] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OpiskelijaID] in table 'Leimaus'
ALTER TABLE [dbo].[Leimaus]
ADD CONSTRAINT [PK_Leimaus]
    PRIMARY KEY CLUSTERED ([OpiskelijaID] ASC);
GO

-- Creating primary key on [LuokkahuoneID] in table 'Luokkahuone'
ALTER TABLE [dbo].[Luokkahuone]
ADD CONSTRAINT [PK_Luokkahuone]
    PRIMARY KEY CLUSTERED ([LuokkahuoneID] ASC);
GO

-- Creating primary key on [OpettajaID] in table 'Opettajat'
ALTER TABLE [dbo].[Opettajat]
ADD CONSTRAINT [PK_Opettajat]
    PRIMARY KEY CLUSTERED ([OpettajaID] ASC);
GO

-- Creating primary key on [OpiskelijaID] in table 'Opiskelijat'
ALTER TABLE [dbo].[Opiskelijat]
ADD CONSTRAINT [PK_Opiskelijat]
    PRIMARY KEY CLUSTERED ([OpiskelijaID] ASC);
GO

-- Creating primary key on [OpiskelijaID] in table 'Tuntiraportti'
ALTER TABLE [dbo].[Tuntiraportti]
ADD CONSTRAINT [PK_Tuntiraportti]
    PRIMARY KEY CLUSTERED ([OpiskelijaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LuokkahuoneID] in table 'Leimaus'
ALTER TABLE [dbo].[Leimaus]
ADD CONSTRAINT [FK_Luokkahuone]
    FOREIGN KEY ([LuokkahuoneID])
    REFERENCES [dbo].[Luokkahuone]
        ([LuokkahuoneID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Luokkahuone'
CREATE INDEX [IX_FK_Luokkahuone]
ON [dbo].[Leimaus]
    ([LuokkahuoneID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------