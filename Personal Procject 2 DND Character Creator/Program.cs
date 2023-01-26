using Personal_Procject_2_DND_Character_Creator;
using Validation;
bool getSystemReset = false;

//Dictionaries
Dictionary<int, string> raceMenu = new Dictionary<int, string>()
{
  {1, "Dragonborn"},
  {2, "Dwarf"},
  {3, "Elf"},
  {4, "Gnome"},
  {5, "Half-Elf"},
  {6, "Halfling"},
  {7, "Half-Orc"},
  {8, "Human"},
  {9, "Tiefling"}
};
Dictionary<int, string> classMenu = new Dictionary<int, string>()
{
  {1,  "Barbarian"},
  {2,  "Bard"},
  {3,  "Cleric"},
  {4,  "Druid"},
  {5,  "Fighter"},
  {6,  "Monk"},
  {7,  "Paladin"},
  {8,  "Ranger"},
  {9,  "Rogue"},
  {10, "Sorcerer"},
  {11, "Warlock"},
  {12, "Wizard"}
};



//Final Class Variable reside here so I can create an instance once everything is selected by user
List<You> CreatedCharacters = new List<You>();
string raceSelect = "";
string classSelect = "";
string characterName = "";


//Intro - Get userName - Display Time of day
Console.WriteLine("Welcome weary traveler, I am Azalaf and this is Personal Project #2: DND Character Creator.\nWhat pray tell is your name?");
string userName = Validator.GetNormalCasing(""); Console.Clear();
Console.WriteLine($"Welcome {userName}. We have a lot to cover, so I will skip the pleasantries." + $"\nToday at {DateTime.Now}, we will construct your own DND character.\n");
///Base intro text
///Console.WriteLine($"Welcome {userName}. We have a lot to cover, so I will skip the pleasantries." +$"\nToday, {DateTime.Now}, we will begin constructing your DND character.\n"); 


//Race Selection Flavor Text
Console.WriteLine($"We will begin by selecting your character's race {userName}.\n\nYour choice of race affects many different aspects of your character. It " +
  "establishes fundamental qualities that exist\nthroughout your character's adventuring career. When making this decision, keep in mind the kind of character " +
  "you want\nto play.\n\nFor example, a halfling could be a good choice for a sneaky rogue, a dwarf makes a tough warrior, and an elf can be\n" +
  "a master of arcane magic.\n\nYour character race not only affects your ability scores and traits, but also provides the cues for building your\ncharacter's story. " +
  "These details are suggestions to help you think about your character; adventurers can deviate widely\nfrom the norm for their race. It's worthwhile to consider why " +
  "your character is different, as a helpful way to think\nabout your character's background and personality.");

Console.WriteLine("\nPress any key to move on when you have finished reading.");
Console.ReadKey(); Console.Clear();


//Race Selection Section
bool chooseRace = true;
while (chooseRace)
{
  while (true)
  {
    Console.WriteLine($"Let's start off with picking your character's race {userName}. Choose between the {raceMenu.Count} races listed below by pressing a\nnumber " +
      $"to learn more information about them or press \"0\" to pick a race at random.\n");
    Console.WriteLine("0. Random");
    foreach (KeyValuePair<int, string> kvp in raceMenu)
    {
      Console.WriteLine($"{kvp.Key}. { kvp.Value}");
    }
    Console.WriteLine();

    //Race Selection Time 
    int raceChoiceA = Validator.GetNumberInRangeIntMinMaxMsg("Choose from the options listed above.", "Please make a selection between", 0, 9);
    if (raceMenu.ContainsKey(raceChoiceA))
    {
      raceSelect = raceMenu[raceChoiceA].ToString();
      Console.Clear(); //- Commented out to allow for comparing races - Add back in if compare all/view all feature added. 
      Console.WriteLine($"{raceSelect}:");
      Console.WriteLine(GetRaceInfo(raceSelect)); ;
      break;
    }

    //Random Race Selection
    else if (raceChoiceA == 0)
    {
      int raceChoiceB = Validator.GetRandom(raceChoiceA);

      if (raceMenu.ContainsKey(raceChoiceB))
      {
        raceSelect = raceMenu[raceChoiceB].ToString();
        Console.Clear(); //- Commented out to allow for comparing races - Add back in if compare all/view all feature added. 
        Console.WriteLine($"{raceSelect}:");
        Console.WriteLine(GetRaceInfo(raceSelect));
        break;
      }
    }
  }


  ///if using random selection make loop here that surrournds this block with a part that's off by default and only selected yes if they pick option 11
  //confirm choice or loop back thru
  chooseRace = Validator.MoveOn($"\nYou have selected {raceSelect}.\n\nTo confirm your race selection, select \"Yes\". To select another race, select \"No\".", "Yes", "No");
  ///If no selected console does not clear so player can scroll back up and reference other things while picking.
  ///Set to clear on selection of no if compare all/view all feature added
}


//Class Selection Intro and Flavor Text
Console.Clear();
Console.WriteLine($"Welcome my {raceSelect} friend. You have passed only but a few of the tasks ahead of you before you have your character.\nWe have come to the next " +
  $"choice you have to make. It is time to pick your characters class.\n");

Console.WriteLine($"Every adventurer is a member of a class {userName}. Class broadly describes a character's vocation, what special talents" +
  $"\nhe or she possesses, and the tactics he or she is most likely to employ when exploring a dungeon, fighting monsters,\nor engaging in a tense negotiation." +
  $"\n\nYour character receives a number of benefits from your choice of class. Many of these benefits are class features\nie. capabilities (including spellcasting) " +
  $"that set your character apart from members of other classes. You also gain\na number of proficiencies: armor, weapons, skills, saving throws, and sometimes tools. " +
  $"Your proficiencies define many\nof the things your character can do particularly well, from using certain weapons to telling a convincing lie.");

Console.WriteLine("\nPress any key to move on when you have finished reading.");
Console.ReadKey(); Console.Clear();


///Class Selection Section
///Consult for descriptions: https://www.dndbeyond.com/characters/92630477/builder/class/choose
bool chooseClass = true;
while (chooseClass)
{
  while (true)
  {
    Console.WriteLine();
    Console.WriteLine($"Next, we must determine your character's class {userName}. Choose between the {classMenu.Count} classes listed below by pressing a\nnumber " +
      $"to learn more information about them or press \"0\" to pick a class at random.\n");
    Console.WriteLine("0. Random");
    foreach (KeyValuePair<int, string> kvp in classMenu)
    {
      Console.WriteLine($"{kvp.Key}. { kvp.Value}");
    }
    Console.WriteLine();

    //Classs Selection Time 
    int classChoiceA = Validator.GetNumberInRangeIntMinMaxMsg("Choose from the options listed above.", "Please make a selection between", 0, classMenu.Count);//12
    if (classMenu.ContainsKey(classChoiceA))
    {
      classSelect = classMenu[classChoiceA].ToString();
      Console.Clear(); //- Commented out to allow for comparing classes - Add back in if compare all/view all feature added. 
      Console.WriteLine($"{classSelect}:");
      Console.WriteLine(GetClassInfo(classSelect));
      break;
    }

    //Random Class Selection
    else if (classChoiceA == 0)
    {
      int classChoiceB = Validator.GetRandomEditMinMax(classChoiceA, 1, classMenu.Count); //12

      if (classMenu.ContainsKey(classChoiceB))
      {
        classSelect = classMenu[classChoiceB].ToString();
        Console.Clear(); //- Commented out to allow for comparing classes - Add back in if compare all/view all feature added. 
        Console.WriteLine($"{classSelect}:");
        Console.WriteLine(GetClassInfo(classSelect));
        break;
      }
    }
  }


  ///if using random selection make loop here that surrournds this block with a part that's off by default and only selected yes if they pick option 11
  //confirm choice or loop back thru
  chooseClass = Validator.MoveOn($"\nYou have selected {classSelect}.\n\nTo confirm your class selection, select \"Yes\". To select another class, select \"No\".", "Yes", "No");
}


//Name Selection Intro
Console.Clear();
Console.WriteLine($"Your journey is nearly over fellow traveler. As {AorAn(raceSelect)} {raceSelect} {classSelect.ToLower()} You will surely make many friends and\nenemies during your campaign, but it's important they " +
  $"know which name to praise/curse. So let's decide that.\n\nNow we will select your character's name.\n\n");


//Flavor Text - Tips
Console.WriteLine("Choosing a good name can be hard, so over my years as a guide I've developed these tips:\n\n" +
  "*  Consider your character’s upbringing, race, and region for examples. The son of Bill and Linda Smith isn’t likely" +
  "\n   to be named Gurruk Skullsplitter.\n\n*  Borrow from real world cultures first. To most Americans, foreign names can sound like fantasy names if people\n   have never heard them.\n" +
  "   -  Norse, Swedish, and Northern European names work well for Dwarves\n   -  Celtic Names work well for Elves or Drow (add some z’s and x’s to make a name more Drow-ish)\n" +
  "   -  Humans can take classical Latin names or any name from Latin or Germanic based langues (German, English, French,\n      Spanish etc.)\n\n*  For more high fantasy names, elongate them " +
  "or use long vowel sounds to stretch the name out.\n\n*  Barbarians and Orcs typically use fewer vowels and have more hard consonants: Gorok, Kragrak, etc.\n\n*  Last names are for nobles, " +
  "commoners get trade names: Smith, Cooper, etc. Try foreign words for trades as last names\n   (Forgeron is French for Smith)" +
  "\n\nNow take this knowledge and choose a name that will strike fear in the hearts of those in this realm and the next.");


Console.WriteLine("\nPress any key to move on when you have finished reading.");
Console.ReadKey(); Console.Clear();


//Name Selection Section
Console.WriteLine($"Now what pray tell do we call your character, {userName}?");
Console.WriteLine($"Enter your characters name below");
characterName = Console.ReadLine();
Console.Clear();

///Final Housing of Created Characters
CreatedCharacters.Add(new You(raceSelect, classSelect, characterName));

//Outro
Console.WriteLine($"Congratulations {userName}, you have just created your character.\n\nI'd like to welcome {characterName}, the {raceSelect} {classSelect.ToLower()} to our realm. May your " +
  $"adventure be filled with\ngreat riches, may your cup never run dry, and may your name be known across the lands.");

Console.WriteLine("\nPress any key to move on when you have finished reading.");
Console.ReadKey(); Console.Clear();

Console.WriteLine("Well, that is all I have for you for now. Check back for updates. Feel free to check the code base for ideas of what\nupdates are coming soon. \n\nThis Azlaf signing off.");





///Loop back through
///For entire reloop through if person says they want to make another character, maybe add a while loop that starts off false and if the player selects,
///it triggers a method that swaps the options of all bools back to their initial state so the program loops call it getSystemReset


///Possible future inclusions
///-    Include stats possibly - consult for info: https://www.dndbeyond.com/characters/92630477/builder/ability-scores/manage
///     *   Roll for stats
///     *   Stat arrays
/// 
///-    If CreatedCharacters.Count >1 activate loop that asks if they'd like to display saved characters. Final Housing can become a string 
///     associated with that character and spot in seperate list would need display character method
///     
///-    Random Create - Creates Character at random up to Name 
///     *    Will need to build out selection options
///
///-    View All - for race and class selection options to allow person to scroll through all text before making selection.
///
///-    Make use of time function.
///     *   Edit year to Middle Ages
///     *   Display different entry greetings based on time of day
///         -   Early morning - 5 am - 8 am - "Thank you for joining me under the light of dawn for this most important of journeys" 
///         -   Morning - 8 am - 12 pm - "Though the day has just begun, we must press on as we have a lot to cover" 
///         -   Aftenoon - 12 pm - 6 pm - Regular display - copy of commented out
///         -   Evening - 6 pm - 9 pm - "Hurry, hurry, my friend. The sunset is nearly upon us, we don't have much time to waste"
///         -   Night - 9 pm - 5 am - "Let my mage light illuminate you on your journey. The cover of darkness will not stop you on this quest"
///     * Display different messages based on Seasons
///         -   Winter - "We have to be quick, they have foretold a blizzard is nearly upon us"
///         -   Spring - 
///         -   Summer - 
///         -   Fall - 
/// 


//Methods
static string GetRaceInfo(string x)
{
  if (x == "Dragonborn")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Dwarf")
  {
    return "Bold end hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal.\n\nRacial Traits\n+2 Constitution, Darkvision, Dwarven Resilience, Dwarven Combat Training, Stonecunning ";
  }
  else if (x == "Elf")
  {
    return "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it. They are known to\nbe adept at magic.\n\nRacial Traits\n+2 Dexterity, Darkvision, Keen Senses, Fey Ancestry, Trance ";
  }
  else if (x == "Gnome")
  {
    return "A Gnome's energy and enthusiasm for living shines through every inch of his or her tiny body.\n\nRacial Traits\n+2 Intelligence, Darkvision, Gnome Cunning";
  }
  else if (x == "Half-Elf")
  {
    return "Half-Elves combine what some say are the best qualities of their Elf and Human parents.\n\nRacial Traits\n+2 Charisma, +1 to Two Other Ability Scores, Darkvision, Fey Ancestry, Skill Versatility";
  }
  else if (x == "Halfling")
  {
    return "The diminutive Halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding\noffense. They are small and nimble, half the height of a human, but fairly stout.\n\nRacial Traits\n+2 Dexterity, Lucky, Brave, Raffling Nimbleness";
  }
  else if (x == "Half-Orc")
  {
    return "Some Half-Orcs rise to become proud leaders of Orc communities. Some venture into the world to prove their worth. Many\nof these become adventurers, achieving greatness for their mighty deeds. They also tend to make excellent warriors,\nespecially Barbarians.\n\nRacial Traits\n+2 Strength, +1 Constitution, Darkvision, Menacing, Relentless Endurance, Savage Attacks";
  }
  else if (x == "Human")
  {
    return "Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the\ninnovators, the achievers, and the pioneers of the worlds.\n\nRacial Traits\n+1 to All Ability Scores, Extra Language";
  }
  else
  {
    return "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in\nevery eye: this is the lot of the Tiefling as they bear the distinct marks of their infernal ancestry: horns, a tail,\npointed teeth, and solid-colored eyes.\n\nRacial Traits\n+2 Charisma, +1 Intelligence, Darkvision, Hellish Resistance, Infernal Legacy";
  }
}

static string GetClassInfo(string x)
{
  if (x == "Barbarian")
  {
    return "A fierce warrior of primitive background who can enter a battle rage.\n\nHit Die: d12\nPrimary Ability: Strength\nSaves: Strength & Constitution\n\nProficiencies\nTools: None\nArmor: Light armor, medium armor, shields\nWeapons: Simple weapons, martial weapons\n\nSaving Throws: Strength, Constitution\nSkills: Choose two from Animal Handling, Athletics, Intimidation, Nature, Perception, and Survival";
  }
  else if (x == "Bard")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Cleric")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Druid")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Fighter")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Monk")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Paladin")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Ranger")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Rogue")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Sorcerer")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if (x == "Warlock")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail. They tend\nto make excellent warriors.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }

}

static string AorAn (string x)
{
  string p = x;
  if (p == "Elf")
  {
    return "an";
  }
  else 
  {
    return "a";
  }
}

///9 Basic Character Descriptions
///
//1. Dragonborn
//Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail.

//Racial Traits
//+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance

//2. Dwarf
//Bold end hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal.

//\n\nRacial Traits\n
//+2 Constitution, Darkvision, Dwarven Resilience, Dwarven Combat Training, Stonecunning 

//3. Elf
//Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.

//\n\nRacial Traits\n
//+2 Dexterity, Darkvision, Keen Senses, Fey Ancestry, Trance 

//4. Gnome
//A gnome's energy and enthusiasm for living shines through every inch of his or her tiny body.

//\n\nRacial Traits\n
//+2 Intelligence, Darkvision, Gnome Cunning

//5. Half-Elf
//Half-elves combine what some say are the best qualities of their elf and human parents.

//\n\nRacial Traits\n
//+2 Charisma, +1 to Two Other Ability Scores, Darkvision, Fey Ancestry, Skill Versatility

//6. Halfling
//The diminutive halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding offense.

//\n\nRacial Traits\n
//+2 Dexterity, Lucky, Brave, Raffling Nimbleness

//7. Half-Orc
//Some half-orcs rise to become proud leaders of orc communities. Some venture into the world to prove their worth. Many of these become
//adventurers, achieving greatness for their mighty deeds.

//\n\nRacial Traits\n
//+2 Strength, +1 Constitution, Darkvision, Menacing, Relentless Endurance, Savage Attacks

//8. Human
//Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and
//the pioneers of the worlds.

//\n\nRacial Traits\n
//+1 to All Ability Scores, Extra Language

//9. Tiefling
//To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling.

//\n\nRacial Traits\n
//+2 Charisma, +1 Intelligence, Darkvision, Hellish Resistance, Infernal Legacy


///Basic Class Descriptions
///
//1. Barbarian"\nA fierce warrior of primitive background who can enter a battle rage.\n\nHit Die: d12\nPrimary Ability: Strength\nSaves: Strength & Constitution\n\nProficiencies\nTools: None\nArmor: Light armor, medium armor, shields\nWeapons: Simple weapons, martial weapons\n\nSaving Throws: Strength, Constitution\nSkills: Choose two from Animal Handling, Athletics, Intimidation, Nature, Perception, and Survival"
///
//2. 
///
//3. 
///
//4. 
///
//5. 
///
//6. 
///
//7. 
///
//8. 
///
//9. 
///
//10. 
///
//11. 
///
//12. 
///


///List Making Style - For Later Use
//1. 
///
//2. 
///
