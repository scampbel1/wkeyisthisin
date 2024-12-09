UPDATE [Core].[ChordDefinition]
SET Popularity = 
    CASE 
        WHEN [Name] IN ('Major', 'Minor') THEN 1
        WHEN [Name] IN ('Dominant Seventh', 'Major Seventh', 'Minor Seventh') THEN 2
        WHEN [Name] IN ('Dominant Thirteenth', 'Major Thirteenth', 'Minor Thirteenth') THEN 3
        WHEN [Name] IN ('Augmented', 'Diminished', 'Dominant Eleventh', 'Major Eleventh', 'Minor Eleventh') THEN 4
        WHEN [Name] IN ('Suspended Fourth', 'Suspended Second') THEN 4
        ELSE 0
    END