CREATE TABLE [dbo].[Races]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Category] NVARCHAR(50) NULL, 
    [Strength] INT NULL, 
    [Dexterity] INT NULL, 
    [Constitution] INT NULL, 
    [Intelligence] INT NULL, 
    [Wisdom] INT NULL, 
    [Charisma] INT NULL, 
)
