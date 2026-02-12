namespace csArbeidskrav1.charactorClasses;

public class Character
{
    private string _name;
    private int _strength;
    private int _intelligence;
    private int _wisdom;
    private int _dexterity;
    private int _constitution;
    private int _charisma;
    private CharacterClass _selectedClass;
    private int _hitPoints;
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int Strength
    {
        get => _strength;
        set => _strength = value;
    }

    public int Intelligence
    {
        get => _intelligence;
        set => _intelligence = value;
    }

    public int Wisdom
    {
        get => _wisdom;
        set => _wisdom = value;
    }

    public int Dexterity
    {
        get => _dexterity;
        set => _dexterity = value;
    }

    public int Constitution
    {
        get => _constitution;
        set => _constitution = value;
    }

    public int Charisma
    {
        get => _charisma;
        set => _charisma = value;
    }
    
    public CharacterClass SelectedClass
    {
        get => _selectedClass;
        set => _selectedClass = value;
    }

    public int HitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value;
    }

    /// <summary>
    /// Rolls three six-sided dice and returns the sum (3-18)
    /// </summary>
    public int RollDice()
    {
        Random random = new  Random();
        int total = 0;

        for (int i = 0; i < 3; i++)
        {
            total += random.Next(1, 7);
        }
        return total;
    }

    /// <summary>
    /// Rolls all six ability scores and handles reroll if average is too low
    /// </summary>

    public void RollAbilityScores()
    {
        Strength = RollDice();
        Intelligence = RollDice();
        Wisdom = RollDice();
        Dexterity = RollDice();
        Constitution = RollDice();
        Charisma = RollDice();
        
        Console.WriteLine("\nRolling ability scores...");
        Console.WriteLine($" Strength: {Strength}");
        Console.WriteLine($" Intelligence: {Intelligence}");
        Console.WriteLine($" Wisdom: {Wisdom}");
        Console.WriteLine($" Dexterity: {Dexterity}");
        Console.WriteLine($" Constitution: {Constitution}");
        Console.WriteLine($" Charisma: {Charisma}");

        int GetAverage()
        {
            return (Strength + Intelligence + Wisdom + Dexterity + Constitution + Charisma) / 6;
        }
        
        int average = GetAverage();
        Console.WriteLine($" Average ability score: {average}");

        if (average <= 8)
        {
            string answer = "";

            while (answer != "Y" && answer != "N")
            {
                Console.Write("\nYour ability scores are below average. Would you like to reroll? (Y/N): ");
                answer = Console.ReadLine().ToUpper();

                if (answer != "Y" && answer != "N")
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            }

            if (answer == "Y")
            {
                RollAbilityScores();
            }
        }
    }
    
    /// <summary>
    /// Gets the two highest ability score VALUES
    /// </summary>
    public int[] GetTopTwoScores()
    {
        int[] allScores = { Strength, Intelligence, Wisdom, Dexterity, Constitution, Charisma };
        Array.Sort(allScores);
        
        int highest = allScores[5];
        int secondHighest = allScores[4];
        
        return new int[] { highest, secondHighest };
    }
    
    /// <summary>
    /// Checks if a specific ability score is in the top two
    /// </summary>
    public bool IsInTopTwo(int score)
    {
        int[] topTwo = GetTopTwoScores();
        return score == topTwo[0] || score == topTwo[1];
    }
    
    /// <summary>
    /// Determines which classes are available based on top two ability scores
    /// </summary>
    public List<CharacterClass> GetAvailableClasses(List<CharacterClass> allClasses)
    {
        List<CharacterClass> availableClasses = new List<CharacterClass>();

        foreach (CharacterClass charClass in allClasses)
        {
            if (charClass.PrimeRequisite == "Strength" && IsInTopTwo(Strength))
            {
                availableClasses.Add(charClass);
            }
            else if (charClass.PrimeRequisite == "Intelligence" && IsInTopTwo(Intelligence))
            {
                availableClasses.Add(charClass);
            }
            else if (charClass.PrimeRequisite == "Wisdom" && IsInTopTwo(Wisdom))
            {
                availableClasses.Add(charClass);
            }
            else if (charClass.PrimeRequisite == "Dexterity" && IsInTopTwo(Dexterity))
            {
                availableClasses.Add(charClass);
            }
        }

        return availableClasses;
    }
    
    /// <summary>
    /// Displays available classes and lets user select one
    /// </summary>
    public CharacterClass SelectClass(List<CharacterClass> allClasses)
    {
        List<CharacterClass> availableClasses = GetAvailableClasses(allClasses);

        Console.WriteLine("\nAvailable classes based on your scores:");

        for (int i = 0; i < availableClasses.Count; i++)
        {
            int displayNumber = i + 1;
            CharacterClass charClass = availableClasses[i];
            Console.WriteLine($" {displayNumber}. {charClass.Name} (Prime: {charClass.PrimeRequisite})");
        }

        if (availableClasses.Count == 1)
        {
            SelectedClass = availableClasses[0];
            Console.WriteLine($"\nOnly one class available. Auto-selecting: {SelectedClass.Name}");
            return SelectedClass;
        }

        Console.Write($"\nSelect a class (1-{availableClasses.Count}): ");
        int choice;
    
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Please enter a number: ");
        }

        while (choice < 1 || choice > availableClasses.Count)
        {
            Console.Write($"Invalid choice. Please select (1-{availableClasses.Count}): ");
            int.TryParse(Console.ReadLine(), out choice);  // ← Changed from int.Parse!
        }

        SelectedClass = availableClasses[choice - 1];
        Console.WriteLine($"\nYou selected: {SelectedClass.Name}");
        return SelectedClass;
    }
    
    /// <summary>
    /// Calculates the ability score modifier based on OSE rules
    /// </summary>
    public int CalculateModifier(int abilityScore)
    {
        if (abilityScore == 3) return -3;
        if (abilityScore >= 4 && abilityScore <= 5) return -2;
        if (abilityScore >= 6 && abilityScore <= 8) return -1;
        if (abilityScore >= 9 && abilityScore <= 12) return 0;
        if (abilityScore >= 13 && abilityScore <= 15) return 1;
        if (abilityScore >= 16 && abilityScore <= 17) return 2;
        if (abilityScore == 18) return 3;

        return 0;
    }
    
    /// <summary>
    /// Rolls hit points based on class hit die and constitution modifier
    /// </summary>
    public int RollHitPoints()
    {
        Random random = new Random();
        int roll = random.Next(1, SelectedClass.HitDie + 1);

        int conModifier = CalculateModifier(Constitution);

        int hitPoints = roll + conModifier;

        if (hitPoints < 1)
        {
            hitPoints = 1;
        }

        HitPoints = hitPoints;

        Console.WriteLine($"\nRolling hit points: 1d{SelectedClass.HitDie} + {conModifier} (CON modifier)");
        Console.WriteLine($"Hit Points: {HitPoints}");

        return hitPoints;
    }
    
    /// <summary>
    /// Displays the completed character sheet
    /// </summary>
    public void DisplayCharacter()
    {
        Console.WriteLine("\n=== Character Created ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Class: {SelectedClass.Name}");
        Console.WriteLine($"Hit Points: {HitPoints}");

        Console.WriteLine("\nAbility Scores:");
        Console.WriteLine($" STR: {Strength}  INT: {Intelligence}  WIS: {Wisdom}");
        Console.WriteLine($" DEX: {Dexterity}  CON: {Constitution}  CHA: {Charisma}");

        int primeScore = 0;
        string primeName = SelectedClass.PrimeRequisite;

        if (primeName == "Strength") primeScore = Strength;
        else if (primeName == "Intelligence") primeScore = Intelligence;
        else if (primeName == "Wisdom") primeScore = Wisdom;
        else if (primeName == "Dexterity") primeScore = Dexterity;

        int primeModifier = CalculateModifier(primeScore);
        string modifierString = primeModifier >= 0 ? $"+{primeModifier}" : primeModifier.ToString();

        Console.WriteLine($"\nPrime Requisite: {primeName} ({primeScore}) - Modifier: {modifierString}");
        Console.WriteLine($"XP for Level 2: {SelectedClass.XpForLevel2:N0}");
    }
}


