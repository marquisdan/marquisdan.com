CREATE PROCEDURE [dbo].[SeedRaces]
	@Core nvarchar(50) = 'Core',
	@Featured nvarchar(50) = 'Featured',
	@Uncommon nvarchar(50) = 'Uncommon',
	@Standard nvarchar(50) = 'Standard',
	@Advanced nvarchar(50) = 'Advanced'

AS
begin
	--Core Races
	if (select count(id) from races where Category = @Core) = 0
		insert into races 
			(Name, Category, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) 
		values 
			('Dwarf', @Core, 0,0,2,0,2,-2),
			('Elf', @Core, 0,2,-2,0,2,0),
			('Gnome', @Core, -2,0,2,0,0,2),
			('Half-Elf', @Core, 0,0,0,0,0,0),
			('Halfling', @Core, -2,2,0,0,0,2),
			('Half-Orc', @Core, 0,0,0,0,0,0),
			('Human', @Core, 0,0,0,0,0,0);
	
	--Featured Races
	if (select count(id) from races where Category = @Featured) = 0
		insert into races 
			(Name, Category, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) 
		values 
			('Aasimar', @Featured, 0,0,0,0,2,2),
			('Catfolk', @Featured, 0,2,0,0,-2,2),
			('Dhampir', @Featured, 0,2,-2,0,0,2),
			('Drow', @Featured, 0,2,-2,0,0,2),
			('Fetchling', @Featured, 0,2,0,0,-2,2),
			('Goblin', @Featured, -2,4,0,0,0,-2),
			('Hobgoblin', @Featured, 0,2,0,0,0,2),
			('Ifrit', @Featured, 0,2,0,0,-2,2),
			('Kobold', @Featured, -4,2,-2,0,0,0),
			('Orc', @Featured, 4,0,0,-2,-2,-2),
			('Oread', @Featured, 2,0,0,0,2,-2),
			('Ratfolk', @Featured, -2,2,0,2,0,0),
			('Sylph', @Featured, 0,2,-2,2,0,0),
			('Tengu', @Featured, 0,2,-2,0,2,0),
			('Tiefling', @Featured, 0,2,0,2,0,-2),
			('Undine', @Featured, -2,2,0,0,2,0);

	--Uncommon Races
		if (select count(id) from races where Category = @Uncommon) = 0
		insert into races 
			(Name, Category, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) 
		values 
			('Changeling', @Uncommon, 0,0,-2,0,2,2),
			('Duergar', @Uncommon, 0,0,2,0,2,-4),
			('Gilman', @Uncommon, 0,0,2,0,-2,2),
			('Grippli', @Uncommon, -2,2,0,0,0,2),
			('Merfolk', @Uncommon, 0,2,2,0,0,2),
			('Nagaji', @Uncommon, 2,0,0,-2,0,2),
			('Samsaran', @Uncommon, 0,0,2,2,2,0),
			('Strix', @Uncommon, 0,2,0,0,0,-2),
			('Suli', @Uncommon, 2,0,0,-2,0,2),
			('Svirfneblin', @Uncommon, -2,2,0,0,2,-2),
			('Vanara', @Uncommon, 0,2,0,0,2,-2),
			('Vishkanya ', @Uncommon, 0,2,0,0,-2,2),
			('Wayangs', @Uncommon, 0,2,0,2,-2,0)

	--Standard Races
		if (select count(id) from races where Category = @Standard) = 0
			insert into races 
				(Name, Category, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) 
			values 
				('Gnoll', @Standard, 2,0,2,0,0,0),
				('LizardFolk', @Standard, 2,0,2,0,0,0),
				('Locathah', @Standard, 0,2,0,-2,2,0),
				('Monkey Goblin', @Standard, 0,4,0,0,-2,-2),
				('Skinwalker', @Standard, 0,0,0,-2,2,0),
				('Triaxian', @Standard, -2,0,2,0,2,0)
	--Advanced Races 
			if (select count(id) from races where Category = @Advanced) = 0
			insert into races 
				(Name, Category, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) 
			values 
				('Android', @Advanced, 0,2,0,2,0,-2),
				('Gathlain', @Advanced, 0,2,-2,0,0,2),
				('Ghoran', @Advanced, 0,0,2,-2,0,2),
				('Kasatha', @Advanced, 0,2,0,0,2,0),
				('Lashunta (Male)', @Advanced, 2,0,0,2,-2,0),
				('Lashunta (Female)', @Advanced, 0,0,-2,2,0,2),
				('Syrinx', @Advanced, 0,-2,0,0,2,0),
				('Triton', @Advanced, 2,-2,0,0,0,2),
				('Wyrwood', @Advanced, 0,2,0,2,0,-2),
				('Wyvaran', @Advanced, 0,2,0,-2,2,0)

end
