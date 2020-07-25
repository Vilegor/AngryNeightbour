using Code.ServerLogic.Data;

namespace Code.ServerLogic
{
    public interface IGameServerController
    {
        GameStateDTO StartGame();
    }
}