using PF2EBattleTracker.API.Models;

namespace PF2EBattleTracker.API
{
    public class CharactersDataStore
    {
        public List<CharacterDto> Characters { get; set; }

        //public static CharactersDataStore Current { get; } = new CharactersDataStore();

        public CharactersDataStore()
        { 
            Characters = new List<CharacterDto>()
            {
                new CharacterDto()
                {
                    CharacterId = 1,
                    Name = "Alison",
                    Conditions = new List<ConditionDto>()
                    {
                        new ConditionDto()
                        {
                            ConditionId = 1,
                            Name = "Clumsy",
                            Source = "Spell",
                            Value = 1
                        }
                    }
                },
                new CharacterDto()
                {
                    CharacterId = 2,
                    Name = "Bob",
                    Conditions = new List<ConditionDto>()
                    {
                        new ConditionDto()
                        {
                            ConditionId = 2,
                            Name = "Off Guard",
                            Source = "Flanked"
                        },
                        new ConditionDto()
                        {
                            ConditionId = 3,
                            Name = "Frightened",
                            Source = "Ghost",
                            Value = 2
                        }
                    }
                },
                new CharacterDto()
                {
                    CharacterId = 3,
                    Name = "Caitlyn",
                    Conditions = new List<ConditionDto>()
                    {
                    }
                }
            };
        }
    }
}
