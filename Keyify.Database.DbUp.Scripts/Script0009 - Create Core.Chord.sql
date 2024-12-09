CREATE TABLE Core.Chord (
	[Id] INT IDENTITY(0, 1) NOT NULL PRIMARY KEY,
	[ChordTypeId] INT NOT NULL,
	[RootNoteId] INT NOT NULL,
	[TuningId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(300) NULL,
	[Tabs] VARBINARY(900) NOT NULL,
	[Created] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[LastModified] DATETIME NULL,
	[Deleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT FK_ChordTypeId FOREIGN KEY (ChordTypeId) REFERENCES Core.ChordDefinition(Id),
	CONSTRAINT FK_RootNoteId FOREIGN KEY (RootNoteId) REFERENCES Core.Note(Id),
	CONSTRAINT FK_TuningId FOREIGN KEY (TuningId) REFERENCES Core.Tuning(Id),
	CONSTRAINT [UQ_Instrument_Chord] UNIQUE NONCLUSTERED
    (
        [TuningId], [RootNoteId], [ChordTypeId], [Tabs]
    )
	)
GO