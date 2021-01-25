CREATE PROCEDURE [dbo].[SeedCoreRaces]
	@bookId int = -1
AS
Begin
	Select @bookId = Id from dbo.Rulebooks where Name = 'Core Rulebook';
	
	if (select count(Id) from dbo.Races where Rulebook_Fk = @bookId) = 0
		insert into dbo.Races (Rulebook_Fk, Name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma)
			values
				(@bookId, 'Dwarf', 0,0,2,0,2,-2),
				(@bookId, 'Elf', 0,2,0,-2,2,0),
				(@bookId, 'Gnome', -2,0,2,0,0,2),
				(@bookId, 'Half-Elf', 0,0,0,0,0,0),
				(@bookId, 'Half-Orc', 0,0,0,0,0,0),
				(@bookId, 'Halfling', -2,2,0,0,0,2),
				(@bookId, 'Human', 0,0,0,0,0,0)
End
