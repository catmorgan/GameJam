using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour
{
    public Transform FloorTile;
    public float playerDirection;
    private Vector3 prevPosition;
    private Quaternion prevRotation;
    private float speed;

    void Start()
    {
        prevPosition = transform.position;
        prevRotation = transform.rotation;
        speed = FloorTile.localScale.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.S))
                transform.rotation = Quaternion.Euler(0, 180, 0);

        if (Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(0, 0,-90);
        if (Input.GetKeyDown(KeyCode.D))
            transform.rotation = Quaternion.Euler(0, 0, 90);

        if (Input.GetKeyDown(KeyCode.W) && prevRotation == transform.rotation)
            prevPosition.z += speed;
        if (Input.GetKeyDown(KeyCode.S) && prevRotation == transform.rotation)
            prevPosition.z -= speed;
        if (Input.GetKeyDown(KeyCode.A) && prevRotation == transform.rotation)
            prevPosition.x -= speed;
        if (Input.GetKeyDown(KeyCode.D) && prevRotation == transform.rotation)
            prevPosition.x += speed;

        prevRotation = transform.rotation;
        transform.position = prevPosition;
    }
}
