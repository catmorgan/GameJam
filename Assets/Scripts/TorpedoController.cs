using UnityEngine;
using System.Collections;

public class TorpedoController : MonoBehaviour {

    public Transform Water;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            Instantiate(Water, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
