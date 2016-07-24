using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterController : MonoBehaviour {
    public Transform Water;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //Flood();
	}

    public void Flood()
    {
        var WaterTiles = GameObject.FindGameObjectsWithTag("Water");
        var FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
        foreach (var water in WaterTiles)
        {
            foreach (var floor in FloorTiles)
            {
                if (((Mathf.Abs(floor.transform.position.x - water.transform.position.x) <= 1 &&
                    Mathf.Abs(floor.transform.position.z - water.transform.position.z) == 0)) ||
                        ((Mathf.Abs(floor.transform.position.x - water.transform.position.x) == 0 &&
    Mathf.Abs(floor.transform.position.z - water.transform.position.z) <= 1)))
                {
                    Instantiate(water, floor.transform.position, floor.transform.rotation);
                    Destroy(floor);
                }
            }
        }
        var UpdatedWaterTiles = GameObject.FindGameObjectsWithTag("Water");
        foreach (var tile in UpdatedWaterTiles)
        {
            tile.transform.parent = GameObject.Find("Board2").transform;
        }
    }
}
