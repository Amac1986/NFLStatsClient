CREATE DATABASE NFLStats;
GO 
use NFLStats;
GO

CREATE TABLE Player (
    Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Age int,
    Height int,  
    Weight int
);

CREATE TABLE Team (
    Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
    Name VARCHAR(30) NOT NULL
)

CREATE TABLE Position (
    Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
    PositionCode VARCHAR(3) NOT NULL,
    PositionName VARCHAR (30) NOT NULL
)

CREATE TABLE RushingRecords (
    Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
    PlayerID int NOT NULL, 
    TeamId INT NOT NULL, 
    PositionId INT NOT NULL, 
    Attempts int NOT NULL,
    AttemptsPerGame Decimal(5,2) NOT NULL,
    YardsDisplay VARCHAR(3) NOT NULL,
    Yards int NOT NULL,
    AverageYards Decimal(5,2) NOT NULL,
    YardsPerGame Decimal(5,2) NOT NULL,
    TouchDowns int NOT NULL, 
    LongestRunDisplay VARCHAR(3) NOT NULL, 
    LongestRun int NOT NULL, 
    FirstDowns int NOT NULL, 
    PercentageFirstDowns Decimal(5,2) NOT NULL,
    Runs20Plus int NOT NULL, 
    Runs40Plus int NOT NULL, 
    Fumbles int NOT NULL, 
    FOREIGN KEY (PlayerID) REFERENCES Player(Id),
    FOREIGN KEY (TeamId) REFERENCES Team(Id),
    FOREIGN KEY (PositionId) REFERENCES Position(Id)
)
