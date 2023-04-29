using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{

    public enum GameState
    {
        Ready,
        OnDelivery,
        NextTarget
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

    public GameState currentGameState;
    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.Ready;
        currentTarget = Planet.Mars;
    }

    // Update is called once per frame
    void FixedUpdate()
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
    }

    public void GetNewTarget()
    {
        currentTarget = RandomEnumValue<Planet>();
    }
    static System.Random _R = new System.Random();

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(_R.Next(v.Length));
    }
}
