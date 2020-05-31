using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.ServerCommunication;
using Code.ServerCommunication.Data;

namespace Code.FakeServerLogic
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

        public GameDataResponseDTO StartGame()
        {
            var gameData = new GameDataResponseDTO();
            
            return gameData;
        }
    }
}