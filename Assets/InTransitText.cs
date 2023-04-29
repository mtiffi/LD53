using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InTransitText : MonoBehaviour
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
        if (gameStateManager.currentGameState == GameStateManager.GameState.OnDelivery)
        {
            text.enabled = true;
            text.text = "in transit - " + ((int)(gameStateManager.timer * 100)) / 100f;
        }
        else
        {
            text.enabled = false;
        }
    }
}
