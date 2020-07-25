using Code.ServerLogic.Data;
using UnityEngine;

namespace Code.ServerLogic
{
    public class FakeServerController : MonoBehaviour, IGameServerController
    {
        
        // Start is called before the first frame update
        private void Start()
        {

        }
        
        private void Update()
        {
            float d = Time.deltaTime;
        }

        public GameStateDTO StartGame()
        {
            var gameData = new GameStateDTO();
            
            return gameData;
        }
    }
}