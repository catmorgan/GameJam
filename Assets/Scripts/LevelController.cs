using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int TotalPointsPossible;
    public int currentPoints = 0;
    public GUIContent youLose;
    public GUIContent nextLevel;
    public GUIContent youWin;

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
                WinConditions();
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

    void WinConditions()
    {
        //gets at least one sailor
        if (currentPoints > 0 )
        {

        }
        //eats all sailors
        if (currentPoints == TotalPointsPossible)
        {
            CurrentState = TurnState.Win;
        }
    }

    void OnGUI()
    {
        if (CurrentState == TurnState.Win && 
            SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), youWin);
        }
        if (CurrentState == TurnState.Win || (CurrentState == TurnState.Lose && currentPoints > 0))
        {
            if (GUI.Button(new Rect(70,0, Screen.width - 70, Screen.height), nextLevel))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (CurrentState == TurnState.Lose && currentPoints == 0)
        {
           GUI.Box(new Rect(0,0, Screen.width,Screen.height),youLose);
        }
        if (GUI.Button(new Rect(0,70,75,50),"Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        GUI.Box(new Rect(0, 130, 75, 20), "Score: " + currentPoints);
    }

}
