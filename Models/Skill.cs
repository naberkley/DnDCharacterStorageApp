namespace DnDCharacterStorageApp.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; } = string.Empty;

        private bool _hasProficiency = false;
        public bool HasProficiency
        {
            get { return _hasProficiency; }
            set { _hasProficiency = value; }
        }

        private bool _hasExpertise = false;
        public bool HasExpertise
        {
            get { return _hasExpertise; }
            set
            {
                _hasExpertise = value;
                if (value == true)
                {
                    HasProficiency = true;
                }
            }
        }

        public int Score { get; set; } = 0;
        public string Description { get; set; } = string.Empty;

        public int CharacterId { get; set; }
    }
}
