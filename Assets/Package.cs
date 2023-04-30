using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public string target;
    private GameStateManager gameStateManager;

    private HitText hitText;

    public float appliedForces;

    private float timeAlive;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = Camera.main.GetComponent<GameStateManager>();
        hitText = GameObject.Find("HitText").GetComponent<HitText>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateManager.timer <= 0 || transform.position.y < -15 || transform.position.y > 15 || transform.position.x < -20 || transform.position.x > 20)
        {
            hitText.changeText("Miss... ", "", false);
            KillMe();
        }
        timeAlive += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(gameStateManager.currentTarget.ToString());
        if (other.gameObject.name.ToLower() == gameStateManager.currentTarget.ToString().ToLower())
        {
            KillMe();
            gameStateManager.GetNewTarget();
            hitText.changeText("Great delivery!!", "Applied Forces: " + (int)(appliedForces) + " x Flighttime: " + ((int)(timeAlive * 100) / 100f) + " = " + (int)(appliedForces * timeAlive), true);
            gameStateManager.highscore += (int)(appliedForces * timeAlive);
        }
        else
        {
            hitText.changeText("Miss... you hit " + (other.gameObject.name == "sun" ? "the sun" : other.gameObject.name), "", false);
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
