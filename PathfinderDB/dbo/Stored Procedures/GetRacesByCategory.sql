CREATE PROCEDURE [dbo].[GetRacesByCategory]
	@category nvarchar(50)
AS
begin
	select [Id], [Name], [Category], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]
		from Races
		where Category like '%' + @category + '%'
end