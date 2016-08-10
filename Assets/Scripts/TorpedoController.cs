using UnityEngine;
using System.Collections;

public class TorpedoController : MonoBehaviour {
    private LevelController _levelController;
    public Material waterTile01;
    public Renderer Renderer;
    public TorpedoState _TorpedoState;
    public GameObject SharkBite;

    public enum TorpedoState {
        Dead,
        Alive
        }

    // Use this for initialization
    void Start () {
        _levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
        Renderer = GetComponent<Renderer>();
        _TorpedoState = TorpedoState.Alive;
    }
	
    void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Water")
        {
            if (_TorpedoState == TorpedoState.Alive)
            {
                _TorpedoState = TorpedoState.Dead;
                Renderer.material = waterTile01;
            }
        }
    }



    IEnumerator OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player" && _TorpedoState == TorpedoState.Alive)
        {

            var sharkbite = Instantiate(SharkBite, new Vector3(
                Camera.main.transform.position.x,
                2,
                Camera.main.transform.position.z),
                    SharkBite.transform.rotation) as GameObject;

            yield return new WaitForSeconds(0.4f);
            Destroy(sharkbite);
            _TorpedoState = TorpedoState.Dead;
            Renderer.material = waterTile01;
        }
    }
}
