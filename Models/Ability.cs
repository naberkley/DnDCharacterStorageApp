namespace DnDCharacterStorageApp.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string AbilityName { get; set; } = string.Empty;
        public int Score { get; set; } = 10;
        public int Modifier { get; set; } = 0;
        public string Description { get; set; } = string.Empty;

        public bool HasSaveProficiency { get; set; } = false;
        public int SaveBonus { get; set; } = 0;

        public int CharacterId { get; set; }
    }
}
