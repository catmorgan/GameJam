﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int TotalPointsPossible;
    public int currentPoints = 0;

    public enum TurnState
    {
        Start,
        Player,
        Water,
        Victim,
        Lose,
        Win
    }

    public TurnState CurrentState;

    void Start()
    {
        CurrentState = TurnState.Player;
        TotalPointsPossible = GameObject.FindGameObjectsWithTag("Sailor").Length;
    }

    void Update()
    {
        switch (CurrentState)
        {
            case TurnState.Start:
                break;
            case TurnState.Player:
                LoseConditions();
                break;
            case TurnState.Water:
                this.GetComponent<WaterController>().Flood();
                CurrentState = TurnState.Victim;
                break;
            case TurnState.Lose:
                break;
            case TurnState.Win:
                break;
            case TurnState.Victim:
                var sailors = GameObject.FindGameObjectsWithTag("Sailor");
                foreach(var sailor in sailors)
                {
                    var drownCount = sailor.GetComponent<SailorController>().drownCountdown;
                    if (drownCount > 0) drownCount++;
                        
                }
                CurrentState = TurnState.Player;
                break;
        }
    }

    void LoseConditions() {
        var FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
        if (FloorTiles.Length == 0)
        {
            CurrentState = TurnState.Lose;
        }
    }

    void OnGUI()
    {
        
        if (CurrentState == TurnState.Player)
        {
            //if (GUILayout.Button("End Turn"))
            //{
            //    CurrentState = TurnState.Water;
            //}
        }
        if (CurrentState == TurnState.Lose)
        {
           GUI.Box(new Rect(Screen.width /2, Screen.height/2, 100,100),"You lose");
        }
        if (GUI.Button(new Rect(20,70,100,50),"Restart"))
        {
            SceneManager.LoadScene("Level1");
        }
        GUI.Box(new Rect(20, 130, 100, 50), "Score: " + currentPoints);
    }

}
