using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideText : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private TextMeshProUGUI text;

    public List<GameStateManager.GameState> shownInGameStates;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shownInGameStates.IndexOf(gameStateManager.currentGameState) >= 0)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
