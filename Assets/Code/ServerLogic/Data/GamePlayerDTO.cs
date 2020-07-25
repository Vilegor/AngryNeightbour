using System.Collections.Generic;

namespace Code.ServerLogic.Data
{
    public struct GamePlayerDTO
    {
        public int posId { get; }
        public List<GameActionDTO> availableActions { get; }
        public GameActionCooldownDTO cooldown { get; }

        
    }
}