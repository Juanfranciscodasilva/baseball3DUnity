using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameEnd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState.text = gameState.text +" " + PlayerPrefs.GetString("GameState");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
