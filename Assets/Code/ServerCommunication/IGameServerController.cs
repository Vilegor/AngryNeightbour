using Code.ServerCommunication.Data;

namespace Code.ServerCommunication
{
    public interface IGameServerController
    {
        GameDataResponseDTO StartGame();
    }
}