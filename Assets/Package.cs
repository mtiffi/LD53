using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public string target;
    private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.timer <= 0)
        {
            KillMe();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(gameStateManager.currentTarget.ToString());
        if (other.gameObject.name.ToLower() == gameStateManager.currentTarget.ToString().ToLower())
        {
            KillMe();
            gameStateManager.GetNewTarget();
        }
        else
        {
            KillMe();
        }
        gameStateManager.currentGameState = GameStateManager.GameState.Ready;
    }

    void KillMe()
    {
        Destroy(gameObject);
        gameStateManager.currentGameState = GameStateManager.GameState.Ready;
    }


}
