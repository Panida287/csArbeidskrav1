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
    }
    
}

