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

        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public string Alignment { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        [DisplayName("Hit Points")]
        public int HitPoints { get; set; } = 10;
        public int Speed { get; set; } = 30;
        [DisplayName("Armor Class")]
        public int ArmorClass { get; set; } = 10;
        [DisplayName("Proficiency Bonus")]
        public int ProficiencyBonus { get; set; } = 2;
        [DisplayName("Initiative Bonus")]
        public string InitiativeBonus { get; set; } = "+0";

        public IList<Ability> AbilitiesList { get; set; }
        public IList<Skill> SkillsList { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
    }
}
