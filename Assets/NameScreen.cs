using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScreen : MonoBehaviour
{

    private GameStateManager gameStateManager;
    public GameObject[] children;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.currentGameState != GameStateManager.GameState.EnterName)
        {
            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }
        }
    }
}
