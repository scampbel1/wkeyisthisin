UPDATE [Core].[ChordDefinition]
SET [Popularity] = 0
WHERE [Name] IN ('Ionian', 'Aeolian');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 1
WHERE [Name] IN ('Blues', 'Major Pentatonic', 'Minor Pentatonic', 'Dorian', 
                 'Mixolydian', 'Lydian', 'Phrygian', 'Harmonic Minor', 'Melodic Minor');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 2
WHERE [Name] IN ('Altered', 'Byzantine', 'Egyptian', 'Eight Tone Spanish', 
                 'Hungarian Minor', 'Iwato', 'Locrian', 'Locrian 2', 
                 'Neopolitan', 'Neopolitan Major', 'Persian');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 3
WHERE [Name] IN ('Altered bb7', 'Augmented', 'Augmented Ionian', 'Augmented Lydian', 
                 'Balinese Pelog', 'Chinese', 'Diminished Half Whole', 
                 'Diminished Lydian', 'Diminished Whole Half', 'Dorian ♯4', 
                 'Dorian b2', 'Hungarian Major', 'Leading Whole Tone', 
                 'Minor Lydian', 'Mixolydian b6', 'Prometheus', 
                 'Prometheus Neopolitan', 'Whole Tone');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 4
WHERE [Name] IN ('Arabian', 'Bayati', 'Kumoi', 'Kokinjoshi', 
                 'Enigmatic', 'Ichikosucho', 'Purvi Theta', 
                 'Shang', 'Zhi');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 5
WHERE [Name] IN ('Six Tone Symmetrical', 'Todi Theta');

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 3
WHERE [Name] = 'Hirajoshi';

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 2
WHERE [Name] = 'Locrian ♯6';

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 3
WHERE [Name] = 'Lydian 9';

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 2
WHERE [Name] = 'Lydian b7';

UPDATE [Core].[ChordDefinition]
SET [Popularity] = 3
WHERE [Name] = 'Major Phrygian';
