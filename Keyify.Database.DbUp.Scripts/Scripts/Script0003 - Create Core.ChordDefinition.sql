CREATE TABLE [Core].[ChordDefinition] (
	[Id] INT IDENTITY(0, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL UNIQUE,
	[Intervals] VARBINARY(900) NOT NULL UNIQUE,
	[Created] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	[LastModified] DATETIME NULL,
	[Deleted] BIT NOT NULL DEFAULT 0
	)
GO