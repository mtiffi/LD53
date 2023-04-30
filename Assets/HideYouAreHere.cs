using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideYouAreHere : MonoBehaviour
{

    private GameStateManager gameStateManager;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.currentGameState == GameStateManager.GameState.Ready)
            renderer.enabled = true;
        if (gameStateManager.currentGameState == GameStateManager.GameState.OnDelivery)
            Destroy(gameObject);
    }
}
