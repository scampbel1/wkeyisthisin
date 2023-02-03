CREATE TABLE Core.Chord (
	[Id] INT IDENTITY(0, 1) NOT NULL
	,[ChordTypeId] INT NOT NULL
	,[RootNoteId] INT NOT NULL
	,[TuningId] INT NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
	,[Description] INT NULL
	,[Tabs] VARBINARY(MAX) NOT NULL
	,[Created] DATETIME NOT NULL DEFAULT GETUTCDATE()
	,[LastModified] DATETIME NULL
	,[Deleted] BIT NOT NULL DEFAULT 0
	,CONSTRAINT PK_Chord_Id PRIMARY KEY (Id)
	,CONSTRAINT FK_ChordTypeId FOREIGN KEY (ChordTypeId) REFERENCES Core.ChordType(Id)
	,CONSTRAINT FK_RootNoteId FOREIGN KEY (RootNoteId) REFERENCES Core.Note(Id)
	,CONSTRAINT FK_TuningId FOREIGN KEY (TuningId) REFERENCES Core.Tuning(Id)
	)
GO