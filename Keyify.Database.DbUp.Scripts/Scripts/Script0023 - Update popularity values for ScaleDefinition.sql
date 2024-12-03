UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 0
WHERE [Name] IN ('Ionian', 'Aeolian');
GO

UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 1
WHERE [Id] IN (1, 2, 3, 4, 7, 8, 10, 11, 12);
GO

UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 2
WHERE [Id] IN (6, 18, 19, 21, 24, 29, 30, 32, 36, 46, 47, 49, 71);
GO

UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 3
WHERE [Id] IN (9, 13, 14, 15, 17, 20, 22, 25, 26, 27, 28, 33, 34, 35, 37, 39, 40, 42, 44, 45, 51);
GO

UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 4
WHERE [Id] IN (16, 31, 41, 43, 48, 60, 66, 68, 72);
GO

UPDATE [Core].[ScaleDefinition]
SET [Popularity] = 5
WHERE [Id] IN (23, 38);
GO