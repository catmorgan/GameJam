using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterController : MonoBehaviour {

    private GameObject[] WaterTiles;
    private GameObject[] FloorTiles;
    private List<GameObject> TouchingFloorTiles;
	// Use this for initialization
	void Start () {
        WaterTiles = GameObject.FindGameObjectsWithTag("Water");
        FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision col)
    {

        // Add the GameObject collided with to the list.
        TouchingFloorTiles.Add(col.gameObject);

        // Print the entire list to the console.
        foreach (GameObject gObject in TouchingFloorTiles)
        {
            print(gObject.name);
        }
    }
}
