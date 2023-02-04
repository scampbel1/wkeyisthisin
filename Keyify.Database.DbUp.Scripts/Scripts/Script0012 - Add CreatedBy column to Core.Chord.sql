ALTER TABLE [Core].[Chord]
	ADD [CreatedById] INT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Core].[User](Id)
GO