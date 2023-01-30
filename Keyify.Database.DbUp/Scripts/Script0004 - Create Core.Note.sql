CREATE TABLE Core.Note (
	[Id] INT IDENTITY(1, 1) NOT NULL
	,[Flat] NVARCHAR(5) NOT NULL
	,[Sharp] NVARCHAR(5) NOT NULL
	,CONSTRAINT PK_Note_Id PRIMARY KEY (Id)
	)
GO