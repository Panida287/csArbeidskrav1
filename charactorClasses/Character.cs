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

    public int HitPoints
    {
        get => _hitPoints;
        set => _hitPoints = value;
    }
}