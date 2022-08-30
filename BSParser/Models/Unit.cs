namespace BSParser.Models;


public class Rune
{
    public string TargetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
   
}
public class Weapon
{
    public string Name { get; set; }
    public int MinRange { get; set; }
    public int MaxRange { get; set; }
    public int Attacks { get; set; }
    public int Strength { get; set; }
    public int Damage { get; set; }
    public int Critical { get; set; }
}
public class Unit
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int Move { get; set; }
    public IEnumerable<Weapon> Weapons { get; set; } = new List<Weapon>();
    public List<Rune> Runes { get; set; }
}