using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootText : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.currentGameState == GameStateManager.GameState.Ready)
        {
            text.enabled = true;
            if (Input.GetMouseButton(0))
            {
                text.text = "Right click to cancel";
            }
            else
            {
                text.text = "Left click to shoot";
            }
        }
        else
        {
            text.enabled = false;
        }
    }
}
