using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public enum GameState
    {
        EnterName,
        Ready,
        Starting,
        OnDelivery,
        NextTarget,
        GameOver
    }

    public TextMeshProUGUI currentTargetText;

    public enum Planet
    {
        Sun,
        Mercury,
        Venus,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }

    public Planet currentTarget;

    public float timer = 10;

    private float deliveryTimer = 30;

    private TextMeshProUGUI playerNameText, timerText;

    public string playerName;

    private GetHighscores getHighscores;

    public int highscore;

    public GameState currentGameState;

    private float restartTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.EnterName;
        currentTarget = Planet.Jupiter;
        playerNameText = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        getHighscores = GetComponent<GetHighscores>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTargetText.text = "Next delivery: " + currentTarget.ToString();
        if (currentGameState == GameState.OnDelivery)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 10;
        }
        if (currentGameState == GameState.OnDelivery || currentGameState == GameState.Ready)
        {
            deliveryTimer -= Time.deltaTime;
            timerText.text = ((int)(deliveryTimer * 100) / 100f).ToString();
        }
        if (deliveryTimer <= 0 && currentGameState != GameState.GameOver)
        {
            EndGame();
        }
        if (Input.GetKey(KeyCode.R))
        {
            restartTimer += Time.deltaTime;
            if (restartTimer > 2)
                SceneManager.LoadScene("Main");
        }
    }

    public void GetNewTarget()
    {
        currentTarget = RandomEnumValue<Planet>();
        if (highscore > 100000)
            deliveryTimer = 15;
        else if (highscore > 50000)
            deliveryTimer = 20;
        else if (highscore > 10000)
            deliveryTimer = 25;
        else deliveryTimer = 30;

    }

    public void StartGame()
    {
        if (playerNameText.text.Length > 0)
        {
            playerName = playerNameText.text;
            Invoke("EnablePlayerShooting", .3f);
            currentGameState = GameState.Starting;
        }

    }

    public void EndGame()
    {
        currentGameState = GameState.GameOver;
        getHighscores.PostHighScore(playerName, highscore);

    }

    void EnablePlayerShooting()
    {
        currentGameState = GameState.Ready;

    }
    static System.Random _R = new System.Random();

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(_R.Next(v.Length));
    }
}
