using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlanet : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private Transform earth;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = GetComponent<GameStateManager>();
        earth = GameObject.Find("earth").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStateManager.currentGameState == GameStateManager.GameState.OnDelivery || gameStateManager.currentGameState == GameStateManager.GameState.Ready)
        {
            transform.position = new Vector3(earth.position.x, earth.position.y, -10);
        }
    }
}
