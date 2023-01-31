CREATE TABLE Core.Tuning (
	[Id] INT IDENTITY(0, 1) NOT NULL
	,[InstrumentId] INT NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
	,[Description] NVARCHAR(500) NULL
	,[Notes] BINARY NOT NULL
	,[Created] DATETIME NOT NULL
	,[LastModified] DATETIME NOT NULL
	,[Deleted] BIT NOT NULL
	,CONSTRAINT PK_Tuning_Id PRIMARY KEY (Id)
	,CONSTRAINT FK_InstrumentId FOREIGN KEY (InstrumentId) REFERENCES Core.Instrument(Id)	
	)
GO