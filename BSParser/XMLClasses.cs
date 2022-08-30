using System.Xml.Serialization;

namespace BSParser;



[XmlRoot(ElementName = "categoryEntry", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class CategoryEntry
{
    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }
}

[XmlRoot(ElementName = "categoryEntries", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class CategoryEntries
{
    [XmlElement(ElementName = "categoryEntry", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<CategoryEntry> CategoryEntry { get; set; }
}

[XmlRoot(ElementName = "entryLink", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class EntryLink
{
    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "collective")]
    public string Collective { get; set; }

    [XmlAttribute(AttributeName = "import")]
    public string Import { get; set; }

    [XmlAttribute(AttributeName = "targetId")]
    public string TargetId { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
}

[XmlRoot(ElementName = "entryLinks", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class EntryLinks
{
    [XmlElement(ElementName = "entryLink", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<EntryLink> EntryLink { get; set; }


}

[XmlRoot(ElementName = "infoGroup", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class InfoGroup
{
    [XmlElement(ElementName = "profiles", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public Profiles Profiles { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlElement(ElementName = "rules", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public Rules Rules { get; set; }
}

[XmlRoot(ElementName = "infoGroups", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class InfoGroups
{
    [XmlElement(ElementName = "infoGroup", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public InfoGroup InfoGroup { get; set; }
}

[XmlRoot(ElementName = "sharedSelectionEntries",
    Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class SharedSelectionEntries
{
    [XmlElement(ElementName = "selectionEntry",
        Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<SelectionEntry> SelectionEntry { get; set; }
}

[XmlRoot(ElementName = "conditionGroup", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class ConditionGroup
{
    [XmlElement(ElementName = "conditions", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public Conditions Conditions { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
}

[XmlRoot(ElementName = "conditionGroups", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class ConditionGroups
{
    [XmlElement(ElementName = "conditionGroup",
        Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<ConditionGroup> ConditionGroup { get; set; }
}

[XmlRoot(ElementName = "rule", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class Rule
{
    [XmlElement(ElementName = "modifiers", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public Modifiers Modifiers { get; set; }

    [XmlElement(ElementName = "description", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public string Description { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }
}

[XmlRoot(ElementName = "rules", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class Rules
{
    [XmlElement(ElementName = "rule", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<Rule> Rule { get; set; }
}

[XmlRoot(ElementName = "sharedInfoGroups", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class SharedInfoGroups
{
    [XmlElement(ElementName = "infoGroup", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public List<InfoGroup> InfoGroup { get; set; }
}

[XmlRoot(ElementName = "catalogue", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
public class Catalogue
{
    [XmlElement(ElementName = "categoryEntries",
        Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public CategoryEntries CategoryEntries { get; set; }

    [XmlElement(ElementName = "entryLinks", Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public EntryLinks EntryLinks { get; set; }

    [XmlElement(ElementName = "sharedSelectionEntries",
        Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public SharedSelectionEntries SharedSelectionEntries { get; set; }

    [XmlElement(ElementName = "sharedInfoGroups",
        Namespace = "http://www.battlescribe.net/schema/catalogueSchema")]
    public SharedInfoGroups SharedInfoGroups { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "revision")]
    public string Revision { get; set; }

    [XmlAttribute(AttributeName = "battleScribeVersion")]
    public string BattleScribeVersion { get; set; }

    [XmlAttribute(AttributeName = "library")]
    public string Library { get; set; }

    [XmlAttribute(AttributeName = "gameSystemId")]
    public string GameSystemId { get; set; }

    [XmlAttribute(AttributeName = "gameSystemRevision")]
    public string GameSystemRevision { get; set; }

    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }
}



[XmlRoot(ElementName = "constraint")]
public class Constraint
{
    [XmlAttribute(AttributeName = "field")]
    public string Field { get; set; }

    [XmlAttribute(AttributeName = "scope")]
    public string Scope { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }

    [XmlAttribute(AttributeName = "percentValue")]
    public string PercentValue { get; set; }

    [XmlAttribute(AttributeName = "shared")]
    public string Shared { get; set; }

    [XmlAttribute(AttributeName = "includeChildSelections")]
    public string IncludeChildSelections { get; set; }

    [XmlAttribute(AttributeName = "includeChildForces")]
    public string IncludeChildForces { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
}

[XmlRoot(ElementName = "constraints")]
public class Constraints
{
    [XmlElement(ElementName = "constraint")]
    public List<Constraint> Constraint { get; set; }
}

[XmlRoot(ElementName = "condition")]
public class Condition
{
    [XmlAttribute(AttributeName = "field")]
    public string Field { get; set; }

    [XmlAttribute(AttributeName = "scope")]
    public string Scope { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }

    [XmlAttribute(AttributeName = "percentValue")]
    public string PercentValue { get; set; }

    [XmlAttribute(AttributeName = "shared")]
    public string Shared { get; set; }

    [XmlAttribute(AttributeName = "includeChildSelections")]
    public string IncludeChildSelections { get; set; }

    [XmlAttribute(AttributeName = "includeChildForces")]
    public string IncludeChildForces { get; set; }

    [XmlAttribute(AttributeName = "childId")]
    public string ChildId { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
}

[XmlRoot(ElementName = "conditions")]
public class Conditions
{
    [XmlElement(ElementName = "condition")]
    public Condition Condition { get; set; }
}

[XmlRoot(ElementName = "modifier")]
public class Modifier
{
    [XmlElement(ElementName = "conditions")]
    public Conditions Conditions { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

    [XmlAttribute(AttributeName = "field")]
    public string Field { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "modifiers")]
public class Modifiers
{
    [XmlElement(ElementName = "modifier")] public List<Modifier> Modifier { get; set; }
}

[XmlRoot(ElementName = "characteristic")]
public class Characteristic
{
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "typeId")]
    public string TypeId { get; set; }

    [XmlText] public string Text { get; set; }
}

[XmlRoot(ElementName = "characteristics")]
public class Characteristics
{
    [XmlElement(ElementName = "characteristic")]
    public List<Characteristic> Characteristic { get; set; }
}

[XmlRoot(ElementName = "profile")]
public class Profile
{
    [XmlElement(ElementName = "characteristics")]
    public Characteristics Characteristics { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "typeId")]
    public string TypeId { get; set; }

    [XmlAttribute(AttributeName = "typeName")]
    public string TypeName { get; set; }
}

[XmlRoot(ElementName = "profiles")]
public class Profiles
{
    [XmlElement(ElementName = "profile")] public List<Profile> Profile { get; set; }
}

[XmlRoot(ElementName = "infoLink")]
public class InfoLink
{
    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "targetId")]
    public string TargetId { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
}

[XmlRoot(ElementName = "infoLinks")]
public class InfoLinks
{
    [XmlElement(ElementName = "infoLink")] public InfoLink InfoLink { get; set; }
}

[XmlRoot(ElementName = "cost")]
public class Cost
{
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "typeId")]
    public string TypeId { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "costs")]
public class Costs
{
    [XmlElement(ElementName = "cost")] public Cost Cost { get; set; }
}

[XmlRoot(ElementName = "selectionEntry")]
public class SelectionEntry
{
    [XmlElement(ElementName = "modifiers")]
    public Modifiers Modifiers { get; set; }

    [XmlElement(ElementName = "profiles")] public Profiles Profiles { get; set; }

    [XmlElement(ElementName = "infoLinks")]
    public InfoLinks InfoLinks { get; set; }

    [XmlElement(ElementName = "costs")] public Costs Costs { get; set; }
    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "collective")]
    public string Collective { get; set; }

    [XmlAttribute(AttributeName = "import")]
    public string Import { get; set; }

    [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

    [XmlElement(ElementName = "categoryLinks")]
    public CategoryLinks CategoryLinks { get; set; }
    [XmlElement(ElementName = "selectionEntryGroups")]
    public SelectionEntryGroups SelectionEntryGroups { get; set; }
}

[XmlRoot(ElementName = "categoryLink")]
public class CategoryLink
{
    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "targetId")]
    public string TargetId { get; set; }

    [XmlAttribute(AttributeName = "primary")]
    public string Primary { get; set; }
}

[XmlRoot(ElementName = "categoryLinks")]
public class CategoryLinks
{
    [XmlElement(ElementName = "categoryLink")]
    public List<CategoryLink> CategoryLink { get; set; }
}

[XmlRoot(ElementName = "selectionEntries")]
public class SelectionEntries
{
    [XmlElement(ElementName = "selectionEntry")]
    public List<SelectionEntry> SelectionEntry { get; set; }
}

[XmlRoot(ElementName = "selectionEntryGroup")]
public class SelectionEntryGroup
{
    [XmlElement(ElementName = "constraints")]
    public Constraints Constraints { get; set; }

    [XmlElement(ElementName = "selectionEntries")]
    public SelectionEntries SelectionEntries { get; set; }

    [XmlAttribute(AttributeName = "id")] public string Id { get; set; }
    [XmlAttribute(AttributeName = "name")] public string Name { get; set; }

    [XmlAttribute(AttributeName = "hidden")]
    public string Hidden { get; set; }

    [XmlAttribute(AttributeName = "collective")]
    public string Collective { get; set; }

    [XmlAttribute(AttributeName = "import")]
    public string Import { get; set; }

    [XmlAttribute(AttributeName = "defaultSelectionEntryId")]
    public string DefaultSelectionEntryId { get; set; }
}

[XmlRoot(ElementName = "selectionEntryGroups")]
public class SelectionEntryGroups
{
    [XmlElement(ElementName = "selectionEntryGroup")]
    public SelectionEntryGroup SelectionEntryGroup { get; set; }
}