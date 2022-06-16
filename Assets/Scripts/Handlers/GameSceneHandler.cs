using System.Linq;
using Managers;
using Serializables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Handlers
{
    public class GameSceneHandler : MonoBehaviour
    {
        public GameInfo currentGameInfo;
        public GameObject playerPrefab;
        //public GameObject yourTurnText;
        private float tiempoJuego = 120;
        private int interval = 15;
        [SerializeField] private TextMeshProUGUI TimerText;


        private void Start()
        {
            PlayerPrefs.DeleteAll();

            TimerText.text = tiempoJuego.ToString();

            /*var players = MainManager.Instance.gameManager.currentGameInfo.playersIds;
            foreach (var player in players)
            {
                var newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
                var newPlayerHandler = newPlayer.GetComponent<PlayerHandler>();

                newPlayerHandler.playerId = player;
                newPlayerHandler.localPlayer = player == MainManager.Instance.currentLocalPlayerId;
                //newPlayerHandler.yourTurnText = yourTurnText;
            }*/
        }

        void Update()
        {
            tiempoJuego -= Time.deltaTime;
            TimerText.text = tiempoJuego.ToString("0");
            if(Time.frameCount % interval == 0)
            {
                endGame();

            }

            if (tiempoJuego <= 0)
            {
                acabarJuego("empatado");
            }

        }

        public void acabarJuego(string estado)
        {
            if(estado == "empatado")
            {
                MainManager.Instance.gameManager.win(estado, () => endGame()
            , Debug.Log);
            }
            else
            {
                MainManager.Instance.gameManager.win(MainManager.Instance.currentLocalPlayerId, () => endGame()
            , Debug.Log);
            }
            
    
        }
            
        private void endGame()
        {
            var estado = "";
            MainManager.Instance.gameManager.endGame(MainManager.Instance.currentLocalPlayerId, winner =>
            {
                if (winner != "placeholder")
                {
                    Debug.Log("ganador " + winner);
                    if (winner == MainManager.Instance.currentLocalPlayerId)
                    {
                        estado = "ganado";
                    }
                    else if (winner == "empatado")
                    {
                        estado = "empatado";

                    }
                    else if (winner != MainManager.Instance.currentLocalPlayerId)
                    {
                        estado = "perdido";
                    }

                    PlayerPrefs.SetString("GameState", estado);
                    SceneManager.LoadScene("GameEnd");

                }

            }
            , Debug.Log);
            

        }
        public void Leave()
        {
            //MainManager.Instance.gameManager.StopListeningForLocalPlayerTurn();
            var players = MainManager.Instance.gameManager.currentGameInfo.playersIds;
            foreach (var player in players.Where(p => p != MainManager.Instance.currentLocalPlayerId))
                //MainManager.Instance.gameManager.StopListeningForMoves(player);
            SceneManager.LoadScene("MenuScene");
        }

        
    }
}