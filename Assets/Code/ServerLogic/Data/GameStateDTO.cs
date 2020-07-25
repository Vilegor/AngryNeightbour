using System.Collections.Generic;

namespace Code.ServerLogic.Data
{
    public class GameStateDTO
    {
        public int gameId { get; }
        
        public GameLayoutType gameLayout { get; }
        public GameMode gameMode { get; }
        
        public List<GamePlayerDTO> players { get; }
    }
}