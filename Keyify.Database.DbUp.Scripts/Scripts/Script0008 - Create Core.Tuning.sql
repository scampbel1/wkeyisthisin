CREATE TABLE Core.Tuning (
	[Id] INT IDENTITY(0, 1) NOT NULL PRIMARY KEY,
	[InstrumentId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[Notes] VARBINARY(900) NOT NULL,
	[Created] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[LastModified] DATETIME NULL,
	[Deleted] BIT NOT NULL DEFAULT 0,	
	CONSTRAINT FK_InstrumentId FOREIGN KEY (InstrumentId) REFERENCES Core.Instrument(Id),
	CONSTRAINT [UQ_Instrument_Tuning] UNIQUE NONCLUSTERED
    (
        [InstrumentId], [Notes]
    )
	)
GO