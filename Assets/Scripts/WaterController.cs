using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterController : MonoBehaviour {

    private GameObject[] WaterTiles;
    private GameObject[] FloorTiles;
    public Transform Water;

	void Start () {
        WaterTiles = GameObject.FindGameObjectsWithTag("Water");
        FloorTiles = GameObject.FindGameObjectsWithTag("Floor");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Flood()
    {
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
    }
}
