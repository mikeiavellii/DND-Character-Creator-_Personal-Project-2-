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

List<You> CreatedCharacters = new List<You>();
//Final Class Variable reside here so I can create an instance once everything is selected by user
string raceSelect = "";
string classSelect = "";
string characterName = "";


//Intro
Console.WriteLine("Welcome weary traveler, I am Azalaf and this is to Personal Project #2: DND Character Creator.\nWhat pray tell is your name?");
string userName = Validator.GetNormalCasing(""); Console.Clear();
Console.WriteLine($"Welcome {userName}. We have a lot to cover so I will dispense with the pleasantries." +$"\nToday, {DateTime.Now}, we will begin constructing your DND character.\n");


//Race Selection Section
bool chooseRace = true;
while (chooseRace)
{
  while (chooseRace = true) 
  {
    Console.WriteLine("Let's start off with picking your race. Enter a number below to choose between the nine listed \nto see more information about them or pick 0 to pick one at random.\n");
    foreach (KeyValuePair<int, string> kvp in raceMenu)
    {
      Console.WriteLine($"{kvp.Key}. { kvp.Value}");
    }
    Console.WriteLine("0. Random");
    
    //selection time
    int raceChoiceA = Validator.GetUserNumberIntMsg($"Please make a selection.");
    if (raceMenu.ContainsKey(raceChoiceA))
    {
      raceSelect = raceMenu[raceChoiceA].ToString();
      Console.Clear();
      Console.WriteLine($"{raceSelect}:");
      Console.WriteLine(GetRaceInfo(raceSelect));;
      break;
    }
    else if (raceChoiceA == 0)
    {
      int raceChoiceB = Validator.GetRandom(raceChoiceA);

      if (raceMenu.ContainsKey(raceChoiceB))
      {
        raceSelect = raceMenu[raceChoiceB].ToString();
        Console.Clear();
        Console.WriteLine($"{raceSelect}:");
        Console.WriteLine(GetRaceInfo(raceSelect));
        break;
      }
    }
  }
  while (chooseRace)
  {
    //confirm choice or loop back thru
    chooseRace = Validator.MoveOn($"\nYou have selected {raceSelect}.\nTo confirm your race selection, select \"Yes\". To select another race, select \"No\".", "Yes", "No");
  }
  //select No still continues
}


//Class Selection Section
//Consult for descriptions: https://www.dndbeyond.com/characters/92630477/builder/class/choose


//Name Selection Section


//Outro

//Final Housing
//CreatedCharacters.Add(new You(raceSelect, classSelect, characterName));

///Possible future inclusions
///-    Include stats possibly - consult for info: https://www.dndbeyond.com/characters/92630477/builder/ability-scores/manage
///     *   Roll for stats
///     *   Stat arrays
/// 
///-    If CreatedCharacters.Count >1 activate loop that asks if they'd like to display saved characters. Final Housing can become a string 
///     associated with that character and spot in seperate list would need display character method
///


//Loop back through
//For entire reloop through if person says they want to make another character, maybe add a while loop that starts off false and if the player selects,
//it triggers a method that swaps the options of all bools back to their initial state so the program loops call it getSystemReset

//Methods

static string GetRaceInfo(string x)
{
  if ( x == "Dragonborn")
  {
    return "Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail.\n\nRacial Traits\n+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance";
  }
  else if ( x == "Dwarf")
  {
    return "Bold end hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal.\n\nRacial Traits\n+2 Constitution, Darkvision, Dwarven Resilience, Dwarven Combat Training, Stonecunning ";
  }
  else if (x == "Elf")
  {
    return "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.\n\nRacial Traits\n+2 Dexterity, Darkvision, Keen Senses, Fey Ancestry, Trance ";
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
    return "The diminutive Halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding offense.\n\nRacial Traits\n+2 Dexterity, Lucky, Brave, Raffling Nimbleness";
  }
  else if (x == "Half-Orc")
  {
    return "Some Half-Orcs rise to become proud leaders of Orc communities. Some venture into the world to prove their worth. Many of these become adventurers,\nachieving greatness for their mighty deeds.\n\nRacial Traits+2 Strength, +1 Constitution, Darkvision, Menacing, Relentless Endurance, Savage Attacks";
  }
  else if (x == "Human")
  {
    return "Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.\n\nRacial Traits\n+1 to All Ability Scores, Extra Language";
  }
  else 
  {
    return "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye:\nthis is the lot of the Tiefling.\n\nRacial Traits\n+2 Charisma, +1 Intelligence, Darkvision, Hellish Resistance, Infernal Legacy";
  }
}
///Basic Character Descriptions
///
//1. Dragonborn
//Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail.

//Racial Traits
//+2 Strength, +1 Charisma, Draconic Ancestry, Breath Weapon, Damage Resistance
///
//2. Dwarf
//Bold end hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal.

//\n\nRacial Traits\n
//+2 Constitution, Darkvision, Dwarven Resilience, Dwarven Combat Training, Stonecunning 
///
//3. Elf
//Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.

//\n\nRacial Traits\n
//+2 Dexterity, Darkvision, Keen Senses, Fey Ancestry, Trance 
///
//4. Gnome
//A gnome's energy and enthusiasm for living shines through every inch of his or her tiny body.

//\n\nRacial Traits\n
//+2 Intelligence, Darkvision, Gnome Cunning
///
//5. Half-Elf
//Half-elves combine what some say are the best qualities of their elf and human parents.

//\n\nRacial Traits\n
//+2 Charisma, +1 to Two Other Ability Scores, Darkvision, Fey Ancestry, Skill Versatility
///
//6. Halfling
//The diminutive halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding offense.

//\n\nRacial Traits\n
//+2 Dexterity, Lucky, Brave, Raffling Nimbleness
///
//7. Half-Orc
//Some half-orcs rise to become proud leaders of orc communities. Some venture into the world to prove their worth. Many of these become
//adventurers, achieving greatness for their mighty deeds.

//\n\nRacial Traits\n
//+2 Strength, +1 Constitution, Darkvision, Menacing, Relentless Endurance, Savage Attacks
///
//8. Human
//Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and
//the pioneers of the worlds.

//\n\nRacial Traits\n
//+1 to All Ability Scores, Extra Language
///
//9. Tiefling
//To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling.

//\n\nRacial Traits\n
//+2 Charisma, +1 Intelligence, Darkvision, Hellish Resistance, Infernal Legacy