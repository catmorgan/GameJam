using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int TotalPointsPossible = 0;
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

    public void Start()
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
                print("Current Points: "+ currentPoints+" Total Points: "+ TotalPointsPossible);
           //     LoseConditions();
                WinConditions();
                break;
            case TurnState.Water:
                this.GetComponent<WaterController>().Flood();
                CurrentState = TurnState.Victim;
                break;
            case TurnState.Win:
                break;
            case TurnState.Lose:
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

/*    void LoseConditions() {
        var FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
        var Sailors = GameObject.FindGameObjectsWithTag("Sailor");
        if (FloorTiles.Length == 0 || Sailors.Length == 0)
        {
            CurrentState = TurnState.Lose;
        }
    }
*/
    void WinConditions()
    {
        var FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
        var Sailors = GameObject.FindGameObjectsWithTag("Sailor");

        if (FloorTiles.Length == 0 && Sailors.Length > 1)
        {
            CurrentState = TurnState.Lose;
        }

        if (Sailors.Length == 0)
        {
            if (currentPoints == TotalPointsPossible)
            {
                CurrentState = TurnState.Win;
            }
            else
            {
                CurrentState = TurnState.Lose;
            }
        }

    }

    void OnGUI()
    {
      /*  if (CurrentState == TurnState.Win &&  SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
        {
            print("i won everything!");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), youWin);
        }*/
        if (CurrentState == TurnState.Win || (CurrentState == TurnState.Lose && currentPoints > 0))
        {
            print("i never win");
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
