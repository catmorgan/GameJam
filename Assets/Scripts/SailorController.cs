using UnityEngine;
using System.Collections;

public class SailorController : MonoBehaviour {
    private LevelController _levelController;
    public int drownCountdown = 0;
    public GameObject Drowned;
    public GameObject Dead;
    public SpriteRenderer Renderer;
    public SailorState _SailorState;
    public GameObject SharkBite;

    public enum SailorState {
        Dead,
        Alive
        }

    // Use this for initialization
    void Start () {
        _levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
        Renderer = this.GetComponent<SpriteRenderer>();
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

            var sharkbite = Instantiate(SharkBite, new Vector3(
                Camera.main.transform.position.x,
                2,
                Camera.main.transform.position.z),
                    SharkBite.transform.rotation) as GameObject;

            yield return new WaitForSeconds(0.4f);
            Destroy(sharkbite);
            _SailorState = SailorState.Dead;
            Instantiate(Dead, this.transform.position, Dead.transform.rotation);
            _levelController.currentPoints++;
            Destroy(this.gameObject);
            
        }
        if (col.transform.tag == "Water")
        {
            print("sailor hit water");
        }
    }

    void StillAlive()
    {
        if (drownCountdown >= 2)
        {
            _SailorState = SailorState.Dead;
            Instantiate(Drowned, this.transform.position, Drowned.transform.rotation);
            Destroy(this.gameObject);
            //Instantiate(Drowned, this.transform.position, this.transform.rotation);
            //this.gameObject.SetActive(false);
        }
    }
}
