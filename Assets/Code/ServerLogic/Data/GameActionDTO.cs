using System.Collections.Generic;

namespace Code.ServerLogic.Data
{
    public struct GameActionDTO
    {
        public GameActionType type { get; }
        public int actionPower { get; }
        public List<int> availableTargets { get; } // house ids
    }
}