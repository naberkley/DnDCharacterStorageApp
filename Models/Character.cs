using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DnDCharacterStorageApp.Models
{
    public class Character
    {
        public Character()
        {
            Skills = new List<Skill>();
            Abilities = new List<Ability>();
        }

        public int Id { get; set; }


        [Required]
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public int Level { get; set; }
        [DisplayName("Hit Points")]
        public int HitPoints { get; set; }
        public int Speed { get; set; }
        public int Initiative { get; set; }
        [DisplayName("Armor Class")]
        public int ArmorClass { get; set; }
        [DisplayName("Proficiency Bonus")]
        public int ProficiencyBonus { get; set; }
        [DisplayName("Initiative Bonus")]
        public string InitiativeBonus { get; set; }

        public IList<Ability> Abilities { get; set; }
        public IList<Skill> Skills { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public bool HasSaveProficiency(string ability)
        {
            return Abilities.Any(ps => ps.AbilityName == ability && ps.HasSaveProficiency);
        }

        public bool IsProficient(string skill)
        {
            return Skills.Any(ps => ps.SkillName == skill && ps.HasProficiency);
        }

        public bool HasExpertise(string skill)
        {
            return Skills.Any(ps => ps.SkillName == skill && ps.HasExpertise);
        }
    }
}
