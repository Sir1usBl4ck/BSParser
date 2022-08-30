using System.Globalization;
using System.Security.AccessControl;
using System.Xml.Serialization;
using BSParser.Models;

namespace BSParser;

public class Parser
{
    public List<Rune> Runes { get; set; } = new();
    public void CreateUnits(string file)
    {
        var catalogue = GetCatalogue(file);
        var units = GetModels(catalogue.SharedSelectionEntries.SelectionEntry);


        // This is for demo purpose. Do what you wish with the parsed units.
        foreach (var unit in units)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(unit.Name);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"---Wounds:{unit.Wounds}");
            Console.WriteLine($"---Toughness:{unit.Toughness}");
            Console.WriteLine($"---Move:{unit.Move}");
            Console.WriteLine($"---Cost:{unit.Cost}");
            foreach (var weapon in unit.Weapons)
            {
                Console.WriteLine($"********Weapon NAME:{weapon.Name}");
                Console.WriteLine($"--------Weapon Range:{weapon.MinRange}-{weapon.MaxRange}");
                Console.WriteLine($"--------Weapon Attacks:{weapon.Attacks}");
                Console.WriteLine($"--------Weapon Range:{weapon.Strength}");
                Console.WriteLine($"--------Weapon Damage:{weapon.Damage}/{weapon.Critical}");
            }

            Console.WriteLine("**RUNES**");
            Console.WriteLine($"[{string.Join(" - ", unit.Runes.Select(x=>x.Name))}]");
        }
    }
    public List<Unit> GetModels(List<SelectionEntry> selectionEntries)
    {
        var units = new List<Unit>();
        foreach (var entry in selectionEntries.Where(e => e.Type == "model"))
        {

            if (entry.SelectionEntryGroups!=null)
            {
                foreach (var modifier in entry.Modifiers.Modifier.Where(m=>m.Type=="append"))
                {
                    var entryForStats = GetEntryForStats(modifier.Value, entry);
                    var entryForWeapons = GetEntryForWeapons(modifier.Value, entry);
                    var unit = new Unit();
                    unit.Name = entry.Name + " " + modifier.Value;
                    unit.Wounds = GetCharacteristic(entryForStats, "Wounds");
                    unit.Move = GetCharacteristic(entryForStats, "Move");
                    unit.Wounds = GetCharacteristic(entryForStats, "Wounds");
                    unit.Toughness = GetCharacteristic(entryForStats, "Toughness");
                    unit.Weapons = GetWeapons(entryForWeapons);
                    unit.Cost = GetCost(entryForWeapons);
                    unit.Runes = GetRunes(entry);
                    units.Add(unit);

                    if (unit.Cost==0)
                    {
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                var unit = new Unit();
                unit.Name = entry.Name;
                unit.Cost = GetCost(entry);
                unit.Wounds = GetCharacteristic(entry, "Wounds");
                unit.Move = GetCharacteristic(entry, "Move");
                unit.Toughness = GetCharacteristic(entry, "Toughness");
                unit.Runes = GetRunes(entry);
                unit.Wounds = GetCharacteristic(entry, "Wounds");
                unit.Weapons = GetWeapons(entry);

                units.Add(unit);

            }
        }

        return units;

    }

    public int GetCost(SelectionEntry selectionEntry)
    {
        var costString = selectionEntry.Costs.Cost.Value;

        return (int)double.Parse(costString, CultureInfo.InvariantCulture);
    }

    public List<Rune> GetRunes(SelectionEntry entry)
    {
        var runes = new List<Rune>();
            foreach (var link in entry.CategoryLinks.CategoryLink)
            {
                var rune = new Rune
                {
                    Name = link.Name,
                    TargetId = link.TargetId
                };
                if (Runes.All(r => r.TargetId != rune.TargetId))
                {
                    Runes.Add(rune);
                }
                runes.Add(rune);
            }
        

        return runes;
    }
    private List<Weapon> GetWeapons(SelectionEntry selectionEntry)
    {
        var weapons = new List<Weapon>();

        foreach (var profile in selectionEntry.Profiles.Profile.Where(p => p.TypeName == "Weapon"))
        {
            var weapon = new Weapon();
            weapon.Name = profile.Name;
            weapon.Attacks = GetWeaponStat(profile, "Attacks");
            weapon.Strength = GetWeaponStat(profile, "Strength");
            var splitRange = SplitValue(profile, "Range", "-");
            weapon.MinRange = splitRange.a;
            weapon.MaxRange = splitRange.b;
            var splitDamage = SplitValue(profile, "Damage", "/");
            weapon.Damage = splitDamage.a;
            weapon.Critical = splitDamage.b;

            weapons.Add(weapon);

        }

        return weapons;
    }

    private (int a, int b) SplitValue(Profile profile, string value, string separator)
    {
        var splitString = profile.Characteristics.Characteristic.First(c =>
            String.Equals(c.Name, value, StringComparison.CurrentCultureIgnoreCase)).Text.Split(separator);
        var min = 1;
        var max = 0;
        if (splitString.Length > 1)
        {
            min = int.Parse(splitString[0]);
            max = int.Parse(splitString[1]);
        }
        else
        {
            max = int.Parse(splitString[0]);
        }


        return (min, max);
    }

    private int GetWeaponStat(Profile profile, string stat)
    {
        var result = profile.Characteristics.Characteristic.First(c =>
            String.Equals(c.Name, stat, StringComparison.CurrentCultureIgnoreCase)).Text;
        return (int)double.Parse(result, CultureInfo.InvariantCulture);
    }

    private SelectionEntry GetEntryForStats(string profileName, SelectionEntry entry)
    {
        if (entry.Profiles != null)
        {
            return entry;
        }

        return entry.SelectionEntryGroups
            .SelectionEntryGroup
            .SelectionEntries
            .SelectionEntry
            .First(e => e.Name == profileName);

    }

    private SelectionEntry GetEntryForWeapons(string profileName, SelectionEntry entry)
    {
        var name = profileName.Replace("with ", "");
        return entry.SelectionEntryGroups
            .SelectionEntryGroup
            .SelectionEntries
            .SelectionEntry
            .First(e => e.Name == name || e.Name==profileName);
    }
    private int GetCharacteristic(SelectionEntry entry, string characteristicName)
    {
        var result = entry
            .Profiles
            .Profile
            .First(p => p.TypeName == "Model")
            .Characteristics.Characteristic.First(c => c.Name == characteristicName).Text;
        return int.Parse(result, CultureInfo.InvariantCulture);
    }

    public Catalogue GetCatalogue(string filepath)
    {
        using (StreamReader reader = File.OpenText(filepath))
        {
            var serializer = new XmlSerializer(typeof(Catalogue));
            return (Catalogue)serializer.Deserialize(reader);
        }

    }

}