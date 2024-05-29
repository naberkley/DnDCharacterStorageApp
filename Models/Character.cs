using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DnDCharacterStorageApp.Models
{
    public class Character
    {
        public int Id { get; set; }



        [Required]
        public string Name { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        [Required]
        public string Class { get; set; } = string.Empty;
        public string Background { get; set; } = string.Empty;
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int Speed { get; set; }
        public int Initiative { get; set; }
        public int ArmorClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }



        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
    }
}
