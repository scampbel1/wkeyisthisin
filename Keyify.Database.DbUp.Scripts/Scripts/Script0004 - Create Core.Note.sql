CREATE TABLE Core.Note (
	[Id] INT IDENTITY(0, 1) NOT NULL PRIMARY KEY,
	[Flat] NVARCHAR(5) NOT NULL UNIQUE,
	[Sharp] NVARCHAR(5) NOT NULL UNIQUE	
	)
GO