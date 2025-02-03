USE Db_Movies
GO
CREATE TABLE Director (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Birthdate DATE,
    Nationality NVARCHAR(50)
);

CREATE TABLE Movie (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    ReleaseDate DATE,
    Genre NVARCHAR(50),
    DiretorId INT,
    FOREIGN KEY (DiretorId) REFERENCES Director(Id)
);

CREATE TABLE Actor (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Birthdate DATE,
    Nationality NVARCHAR(50)
);

CREATE TABLE ActorMovie (
    MovieId INT,
    ActorId INT,
    PRIMARY KEY (MovieId, ActorId),
    FOREIGN KEY (MovieId) REFERENCES Movie(Id),
    FOREIGN KEY (ActorId) REFERENCES Actor(Id)
);
