namespace DnDCharacterStorageApp.Models
{
    public static class Abilities
    {

        public static readonly Dictionary<string, Dictionary<string, string>> Definitions = new Dictionary<string, Dictionary<string, string>>
        {
            ["Strength"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Str",
                ["Description"] = "Strength measures bodily power, athletic training, and the extent to which you can exert raw physical force.",
            },
            ["Dexterity"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Dex",
                ["Description"] = "Dexterity measures agility, reflexes, and balance.",
            },
            ["Constitution"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Con",
                ["Description"] = "Constitution measures health, stamina, and vital force.",
            },
            ["Intelligence"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Int",
                ["Description"] = "Intelligence measures mental acuity, accuracy of recall, and the ability to reason.",
            },
            ["Wisdom"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Wis",
                ["Description"] = "Wisdom reflects how attuned you are to the world around you and represents perceptiveness and intuition.",
            },
            ["Charisma"] = new Dictionary<string, string>
            {
                ["Abbreviation"] = "Cha",
                ["Description"] = "Charisma measures your ability to interact effectively with others. It includes such factors as confidence and eloquence, " +
                    "and it can represent a charming or commanding personality.",
            }
        };
    }

    public static class Skills
    {

        public static readonly Dictionary<string, Dictionary<string, string>> Definitions = new Dictionary<string, Dictionary<string, string>>
        {
            [ "Acrobatics" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Dexterity",
                ["Description"] = "Your Dexterity (Acrobatics) check covers your attempt to stay on your feet in a tricky situation, " +
                    "such as when you're trying to run across a sheet of ice, balance on a tightrope, or stay upright on a rocking ship's deck. " +
                    "The DM might also call for a Dexterity (Acrobatics) check to see if you can perform acrobatic stunts, including dives, rolls, somersaults, and flips."
            },
            [ "Animal Handling" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Wisdom",
                ["Description"] = "When there is any question whether you can calm down a domesticated animal, keep a mount from getting spooked, or intuit an animal’s intentions, " +
                    "the DM might call for a Wisdom (Animal Handling) check. You also make a Wisdom (Animal Handling) check to control your mount when you attempt a risky maneuver.",
            },
            [ "Arcana" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Intelligence",
                ["Description"] = "Your Intelligence (Arcana) check measures your ability to recall lore about spells, magic items, eldritch symbols, magical traditions, " +
                    "the planes of existence, and the inhabitants of those planes.",
            },
            [ "Athletics" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Strength",
                ["Description"] = "Your Strength (Athletics) check covers difficult situations you encounter while climbing, jumping, or swimming.",
            },
            [ "Deception" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Charisma",
                ["Description"] = "Your Charisma (Deception) check determines whether you can convincingly hide the truth, either verbally or through your actions. " +
                    "This deception can encompass everything from misleading others through ambiguity to telling outright lies. " +
                    "Typical situations include trying to fast-talk a guard, con a merchant, earn money through gambling, pass yourself off in a disguise, " +
                    "dull someone's suspicions with false assurances, or maintain a straight face while telling a blatant lie.",
            },
            [ "History" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Intelligence",
                ["Description"] = "Your Intelligence (History) check measures your ability to recall lore about historical events, legendary people, ancient kingdoms, " +
                    "past disputes, recent wars, and lost civilizations.",
            },
            [ "Insight" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Wisdom",
                ["Description"] = "Your Wisdom (Insight) check decides whether you can determine the true intentions of a creature, such as when searching out a lie " +
                    "or predicting someone’s next move. Doing so involves gleaning clues from body language, speech habits, and changes in mannerisms.",
            },
            [ "Intimidation" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Charisma",
                ["Description"] = "When you attempt to influence someone through overt threats, hostile actions, and physical violence, the DM might ask you to make a " +
                    "Charisma (Intimidation) check. Examples include trying to pry information out of a prisoner, convincing street thugs to back down from a " +
                    "confrontation, or using the edge of a broken bottle to convince a sneering vizier to reconsider a decision.",
            },
            [ "Investigation" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Intelligence",
                ["Description"] = "When you look around for clues and make deductions based on those clues, you make an Intelligence (Investigation) check. " +
                    "You might deduce the location of a hidden object, discern from the appearance of a wound what kind of weapon dealt it, " +
                    "or determine the weakest point in a tunnel that could cause it to collapse. Poring through ancient scrolls in search of a hidden " +
                    "fragment of knowledge might also call for an Intelligence (Investigation) check.",
            },
            [ "Medicine" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Wisdom",
                ["Description"] = "A Wisdom (Medicine) check lets you try to stabilize a dying companion or diagnose an illness.",
            },
            [ "Nature" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Intelligence",
                ["Description"] = "Your Intelligence (Nature) check measures your ability to recall lore about terrain, plants and animals, the weather, and natural cycles.",
            },
            [ "Perception" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Wisdom",
                ["Description"] = "Your Wisdom (Perception) check lets you spot, hear, or otherwise detect the presence of something. It measures your general awareness " +
                    "of your surroundings and the keenness of your senses. For example, you might try to hear a conversation through a closed door, " +
                    "eavesdrop under an open window, or hear monsters moving stealthily in the forest. Or you might try to spot things that are obscured " +
                    "or easy to miss, whether they are orcs lying in ambush on a road, thugs hiding in the shadows of an alley, or candlelight under a closed secret door.",
            },
            [ "Performance" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Charisma",
                ["Description"] = "Your Charisma (Performance) check determines how well you can delight an audience with music, dance, acting, storytelling, or some other form of entertainment.",
            },
            [ "Persuasion" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Charisma",
                ["Description"] = "When you attempt to influence someone or a group of people with tact, social graces, or good nature, the DM might ask you to make a Charisma (Persuasion) check. " +
                    "Typically, you use persuasion when acting in good faith, to foster friendships, make cordial requests, or exhibit proper etiquette. " +
                    "Examples of persuading others include convincing a chamberlain to let your party see the king, negotiating peace between warring tribes, " +
                    "or inspiring a crowd of townsfolk.",
            },
            [ "Religion" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Intelligence",
                ["Description"] = "Your Intelligence (Religion) check measures your ability to recall lore about deities, rites and prayers, religious hierarchies, " +
                    "holy symbols, and the practices of secret cults.",
            },
            [ "Sleight of Hand" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Dexterity",
                ["Description"] = "Whenever you attempt an act of legerdemain or manual trickery, such as planting something on someone else or concealing an object " +
                    "on your person, make a Dexterity (Sleight of Hand) check. The DM might also call for a Dexterity (Sleight of Hand) check " +
                    "to determine whether you can lift a coin purse off another person or slip something out of another person's pocket.",
            },
            [ "Stealth" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Dexterity",
                ["Description"] = "Make a Dexterity (Stealth) check when you attempt to conceal yourself from enemies, slink past guards, slip away without being noticed, " +
                    "or sneak up on someone without being seen or heard.",
            },
            [ "Survival" ] = new Dictionary<string, string>
            {
                ["Ability"] = "Wisdom",
                ["Description"] = "The DM might ask you to make a Wisdom (Survival) check to follow tracks, hunt wild game, guide your group through frozen wastelands, " +
                    "identify signs that owlbears live nearby, predict the weather, or avoid quicksand and other natural hazards.",
            }
        };
    }
    
}
