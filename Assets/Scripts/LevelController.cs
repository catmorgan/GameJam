using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    public float boardSize;
    public float startingPoint = 10;
    public Transform FloorTile;
    public Camera MainCamera;
    // Use this for initialization
    void Start () {
        var squareCenter = FloorTile.localScale.y / 2;
        var parent = new GameObject("Board");
    for (var row = 0; row < boardSize; row++)
        {
            for (var col = 0; col < boardSize; col++)
            {
                    Instantiate(FloorTile, 
                    new Vector3(startingPoint + row + squareCenter, 
                    squareCenter, 
                    startingPoint + col + squareCenter), 
                    Quaternion.identity);
               // FloorTile.transform.parent = parent.transform;
            }
        }
        //MainCamera.transform.position = new Vector3(startingPoint + (boardSize * FloorTile.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
