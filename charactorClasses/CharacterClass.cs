namespace csArbeidskrav1.charactorClasses;

public class CharacterClass
{
    private string _name;
    private int _hitDie;
    private int _xpForLevel2;
    private string _primeRequisite;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int HitDie
    {
        get => _hitDie;
        set => _hitDie = value;
    }
    
    public int XpForLevel2
    {
        get => _xpForLevel2;
        set => _xpForLevel2 = value;
    }   
    
    public string PrimeRequisite
    {
        get => _primeRequisite;
        set => _primeRequisite = value;
    }

    public CharacterClass(String name, int hitDie, int xpForLevel2, string primeRequisite)
    {
        _name = name;
        _hitDie = hitDie;
        _xpForLevel2 = xpForLevel2;
        _primeRequisite = primeRequisite;
    }
}

public class Fighter : CharacterClass
{
    public Fighter() : base("Fighter", 8, 2000, "Strength")
    {
    }
}

public class Thief : CharacterClass
{
    public Thief() : base("Thief", 4, 1200, "Dexterity")
    {
    }
}

public class Cleric : CharacterClass
{
    public Cleric() : base("Cleric", 6, 1500, "Wisdom")
    {
    }
}

public class MagicUser : CharacterClass
{
    public MagicUser() : base("Magic-User", 4, 2500, "Intelligence")
    {
    }
}