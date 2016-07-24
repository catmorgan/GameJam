using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{

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
                CurrentState = TurnState.Player;
                break;
            case TurnState.Lose:
                break;
            case TurnState.Win:
                break;
            case TurnState.Victim:
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
            if (GUILayout.Button("End Turn"))
            {
                CurrentState = TurnState.Water;
            }
        }
        if (CurrentState == TurnState.Lose)
        {
            //GUILayout.TextArea("You lose");
        }
    }

}
