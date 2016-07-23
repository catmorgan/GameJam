using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {
    public float boardSize;
    public float startingPoint = 10;
    public Transform FloorTile;
    public Camera MainCamera;
    public Transform Board;
    // Use this for initialization
    void Start () {
        var squareCenter = FloorTile.localScale.y / 2;
    for (var row = 0; row < boardSize; row++)
        {
            for (var col = 0; col < boardSize; col++)
            {
                    Instantiate(FloorTile, 
                    new Vector3(startingPoint + row + squareCenter, 
                    squareCenter, 
                    startingPoint + col + squareCenter), 
                    Quaternion.identity);
            }
        }
        var tiles = GameObject.FindGameObjectsWithTag("Floor");
        foreach (var tile in tiles)
        {
            tile.transform.parent = Board;
        }
        
        Board.transform.position = new Vector3(startingPoint + (boardSize * FloorTile.localScale.y), squareCenter, startingPoint + (boardSize * FloorTile.localScale.y));
        
        MainCamera.transform.position = new Vector3(Board.transform.position.x - boardSize, 
            20,
            Board.transform.position.z - boardSize);
        MainCamera.orthographicSize = boardSize / 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
