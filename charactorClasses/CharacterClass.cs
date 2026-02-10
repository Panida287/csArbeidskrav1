namespace csArbeidskrav1.charactorClasses;

public class CharacterClass
{
    private string _name;
    private int _hitDie;
    private int _xpForLevel2;
    private string _primeRequiste;

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
    
    public string PrimeRequiste
    {
        get => _primeRequiste;
        set => _primeRequiste = value;
    }

    public CharacterClass(String name, int hitDie, int xpForLevel2, string primeRequiste)
    {
        _name = name;
        _hitDie = hitDie;
        _xpForLevel2 = xpForLevel2;
        _primeRequiste = primeRequiste;
    }
}