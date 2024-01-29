/* Main Database that serves to save databases configurations*/
BEGIN TRANSACTION T1
CREATE DATABASE Musicalog_Main
COMMIT TRANSACTION T1;

BEGIN TRANSACTION T2
USE Musicalog_Main
CREATE TABLE DatabaseConfigurations
(
    TenantId INT,
    SqlConnectionString NVARCHAR(255),
    IsActive BIT
)
COMMIT TRANSACTION T2;

/****************/

BEGIN TRANSACTION T3
CREATE DATABASE Musicalog
COMMIT TRANSACTION T3;

/* Basic Database Structure */

BEGIN TRANSACTION T4

CREATE TABLE AlbumV0
(
    Id NVARCHAR(50) PRIMARY KEY,
    Title NVARCHAR(50),
    ArtistName NVARCHAR(50),
    TypeId NVARCHAR(50),
    Stock INT,
    Cover VARBINARY(MAX)
)

COMMIT TRANSACTION T4

/* Optimized Database Structure

BEGIN TRANSACTION T4

USE Musicalog

CREATE TABLE AlbumType
(
    Id NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(50)
)

CREATE TABLE Artist
(
    Id NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(50)
)

CREATE TABLE FileInfo
(
    Id NVARCHAR(50) PRIMARY KEY,
    /*for other Storage type (Blob for example): Path NVARCHAR(255)*/
    Content VARBINARY(MAX)
)

CREATE TABLE Album
(
    Id NVARCHAR(50) PRIMARY KEY,
    Title NVARCHAR(50),
    ArtistId NVARCHAR(50) FOREIGN KEY REFERENCES Artist(Id),
    TypeId NVARCHAR(50) FOREIGN KEY REFERENCES AlbumType(Id),
    Stock INT,
    CoverId NVARCHAR(50) FOREIGN KEY REFERENCES FileInfo(Id) /* Ideally this should be a reference to a file management DB | a blob location for example */
)


COMMIT TRANSACTION T4;

*/