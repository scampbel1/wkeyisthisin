-- VARBINARY Length set to 900. Read here for more info: https://stackoverflow.com/a/28298683/2087167

CREATE TABLE Core.Tuning (
	[Id] INT IDENTITY(0, 1) NOT NULL
	,[InstrumentId] INT NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
	,[Description] NVARCHAR(500) NULL
	,[Notes] VARBINARY(900) NOT NULL
	,[Created] DATETIME NOT NULL DEFAULT GETUTCDATE()
	,[LastModified] DATETIME NULL
	,[Deleted] BIT NOT NULL DEFAULT 0
	,CONSTRAINT PK_Tuning_Id PRIMARY KEY (Id ASC)
	,CONSTRAINT FK_InstrumentId FOREIGN KEY (InstrumentId) REFERENCES Core.Instrument(Id)	 
	)
GO