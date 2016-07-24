using UnityEngine;
using System.Collections;

public class SailorController : MonoBehaviour {
    private LevelController _levelController;
    public int drownCountdown = 0;
    public Material Drowned;
    public Material Dead;
    public Renderer Renderer;
    public SailorState _SailorState;
    public GameObject SharkBite;

    public enum SailorState {
        Dead,
        Alive
        }

    // Use this for initialization
    void Start () {
        _levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
        Renderer = GetComponent<Renderer>();
        _SailorState = SailorState.Alive;
    }
	
	// Update is called once per frame
	void Update () {
        if (_levelController.CurrentState == LevelController.TurnState.Victim)
        {
            StillAlive();
        }
	}

    void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Water")
        {
            if (_levelController.CurrentState == LevelController.TurnState.Victim && _SailorState == SailorState.Alive)
            {
                drownCountdown++;
                StillAlive();
            }
        }

    }

    IEnumerator OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player" && _SailorState == SailorState.Alive)
        {
            var sharkbite = Instantiate(SharkBite, 
                new Vector3(this.transform.position.x, 2, this.transform.position.z), 
                SharkBite.transform.rotation) as GameObject;
            yield return new WaitForSeconds(0.4f);
            Destroy(sharkbite);
            _SailorState = SailorState.Dead;
            Renderer.material = Dead;
            _levelController.currentPoints++;
        }
    }

    void StillAlive()
    {
        if (drownCountdown >= 2)
        {
            _SailorState = SailorState.Dead;
            Renderer.material = Drowned;
        }
    }
}
