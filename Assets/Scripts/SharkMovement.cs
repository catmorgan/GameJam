using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour
{
    //movement variables
    public Transform FloorTile;
    public float playerDirection;
    private Vector3 pos;
    private float speed;

    void Start()
    {
        pos = transform.position;
        speed = FloorTile.localScale.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            pos.z += speed;
        if (Input.GetKeyDown(KeyCode.S))
            pos.z -= speed;
        if (Input.GetKeyDown(KeyCode.A))
            pos.x -= speed;
        if (Input.GetKeyDown(KeyCode.D))
            pos.x += speed;

        transform.position = pos;
    }
}
