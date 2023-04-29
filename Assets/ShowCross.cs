using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCross : MonoBehaviour
{
    private Transform crossTransform;
    private SpriteRenderer crossSpriteRenderer;

    private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        crossTransform = this.gameObject.transform.GetChild(0).GetComponent<Transform>();
        crossSpriteRenderer = this.gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.currentTarget.ToString().ToLower() == gameObject.name.ToLower())
        {
            crossSpriteRenderer.enabled = true;
        }
        else
        {
            crossSpriteRenderer.enabled = false;
        }

    }
}
