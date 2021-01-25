CREATE PROCEDURE [dbo].[GetAllRaces]
AS
begin
	select [Id], [Name], [Category], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]
	from Races;
end
