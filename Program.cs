using csArbeidskrav1.charactorClasses;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== OSE Character Generator ===");

        // Create all possible classes
        List<CharacterClass> allClasses = new List<CharacterClass>();
        allClasses.Add(new Fighter());
        allClasses.Add(new Thief());
        allClasses.Add(new Cleric());
        allClasses.Add(new MagicUser());

        // Create character
        Character hero = new Character();

        // Roll ability scores
        hero.RollAbilityScores();

        // Get character name
        Console.Write("\nEnter character name: ");
        hero.Name = Console.ReadLine();

        // Select class
        hero.SelectClass(allClasses);

        // Roll hit points
        hero.RollHitPoints();

        // Display character
        hero.DisplayCharacter();

        Console.WriteLine("\nCharacter creation complete!");
    }
}

