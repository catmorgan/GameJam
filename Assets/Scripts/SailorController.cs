﻿using UnityEngine;
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
            _SailorState = SailorState.Dead;
            var sharkbite = Instantiate(SharkBite, new Vector3(
                Camera.main.transform.position.x,
                2,
                Camera.main.transform.position.z),
                    SharkBite.transform.rotation) as GameObject;

            yield return new WaitForSeconds(0.4f);
            Destroy(sharkbite);

            Instantiate(Dead, this.transform.position, Dead.transform.rotation);
            _levelController.currentPoints++;
            Destroy(this.gameObject);
        }
    }

    void StillAlive()
    {
        if (drownCountdown >= 2)
        {
            _SailorState = SailorState.Dead;
            Instantiate(Drowned, this.transform.position, Drowned.transform.rotation);
            _levelController.TotalPointsPossible--;
            Destroy(this.gameObject);
        }
    }
}
