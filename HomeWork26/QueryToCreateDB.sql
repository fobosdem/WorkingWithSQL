CREATE TABLE [dbo].[PostalCode](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[PostalCode] [int] NOT NULL,
	[CityId] [int] NOT NULL
);
ALTER TABLE [dbo].[PostalCode] ADD CONSTRAINT postalCodesCity UNIQUE ([PostalCode], [CityId]);
ALTER TABLE [dbo].[PostalCode] WITH CHECK ADD FOREIGN KEY([CityId]) REFERENCES dbo.City ([Id]);


create database GamesAndCreator;

use GamesAndCreator;


CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[GenreName] [nvarchar] (60) NOT NULL,
	[Description] [nvarchar] (600) NOT NULL
);
ALTER TABLE [dbo].[Genres] ADD UNIQUE ([GenreName]);


CREATE TABLE [dbo].[Creators](
	[Id] [int] IDENTITY (1,1) PRIMARY KEY,
	[CreatorName] [nvarchar] (60) NOT NULL,
	[LicenseNumber] [int] NOT NULL
);
ALTER TABLE [dbo].[Creators] ADD UNIQUE ([CreatorName]);


CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY (1,1) PRIMARY KEY,
	[GameName] [nvarchar] (60) NOT NULL,
	[CreateYear] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[CreatorId] [int] NOT NULL
);
ALTER TABLE [dbo].[Games] ADD CONSTRAINT UniqueNameDate UNIQUE ([GameName], [CreateYear]);
ALTER TABLE [dbo].[Games] WITH CHECK ADD FOREIGN KEY([CreatorId]) REFERENCES dbo.Creators ([Id]);
ALTER TABLE [dbo].[Games] WITH CHECK ADD FOREIGN KEY([GenreId]) REFERENCES dbo.Genres ([Id]);
