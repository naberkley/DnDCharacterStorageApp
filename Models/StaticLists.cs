namespace DnDCharacterStorageApp.Models
{
    public static class Skills
    {
        public static readonly List<string> All = new List<string>
            {
                "Acrobatics",
                "Animal Handling",
                "Arcana",
                "Athletics",
                "Deception",
                "History",
                "Insight",
                "Intimidation",
                "Investigation",
                "Medicine",
                "Nature",
                "Perception",
                "Performance",
                "Persuasion",
                "Religion",
                "Sleight of Hand",
                "Stealth",
                "Survival"
            };

        public static readonly Dictionary<string, string> SkillAbility = new Dictionary<string, string>
            {
                { "Acrobatics", "Dexterity" },
                { "Animal Handling", "Wisdom" },
                { "Arcana", "Intelligence" },
                { "Athletics", "Strength" },
                { "Deception", "Charisma" },
                { "History", "Intelligence" },
                { "Insight", "Wisdom" },
                { "Intimidation", "Charisma" },
                { "Investigation", "Intelligence" },
                { "Medicine", "Wisdom" },
                { "Nature", "Intelligence" },
                { "Perception", "Wisdom" },
                { "Performance", "Charisma" },
                { "Persuasion", "Charisma" },
                { "Religion", "Intelligence" },
                { "Sleight of Hand", "Dexterity" },
                { "Stealth", "Dexterity" },
                { "Survival", "Wisdom" }
            };
    }

    public static class Abilities
    {
        public static readonly List<string> All = new List<string>
            {
                "Strength",
                "Dexterity",
                "Constitution",
                "Wisdom",
                "Intelligence",
                "Charisma"
            };

        public static readonly Dictionary<string, string> Abbreviations = new Dictionary<string, string>
            {
                { "Strength", "Str" },
                { "Dexterity", "Dex" },
                { "Constitution", "Con" },
                { "Wisdom", "Wis" },
                { "Intelligence", "Int" },
                { "Charisma", "Cha" }
            };
    }
    
}
