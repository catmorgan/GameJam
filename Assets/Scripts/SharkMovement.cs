using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour
{
    public Transform FloorTile;
    public Material LeftShark;
    public Material RightShark;
    public Material FrontShark;
    public Material FrontLandShark;
    public Material LeftLandShark;
    public Material RightLandShark;
    public Renderer Renderer;
    private Vector3 prevPosition;
    private Quaternion prevRotation;
    private float speed;
    private FloorType floorType;
    private LevelController _levelController;
    private Direction playerDirection;

    public enum FloorType
    {
        Water,
        Floor
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    void Start()
    {
        prevPosition = transform.position;
        prevRotation = transform.rotation;
        speed = FloorTile.localScale.x * 2;
        Renderer = GetComponent<Renderer>();
        _levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
    }

    void Update() {
        if (_levelController.CurrentState == LevelController.TurnState.Player)
        {
            //DIRECTION
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                UpdateShark(Direction.Up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                UpdateShark(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 90, 90);
                UpdateShark(Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, -270, 90);
                UpdateShark(Direction.Right);
            }
            //MOVEMENT
            if (Input.GetKeyDown(KeyCode.W) && prevRotation == transform.rotation)
            {
                prevPosition.z += speed;
                playerDirection = Direction.Up;
                //UpdateShark(Direction.Up);
                _levelController.CurrentState = LevelController.TurnState.Water;
            }
            if (Input.GetKeyDown(KeyCode.S) && prevRotation == transform.rotation)
            {
                prevPosition.z -= speed;
                playerDirection = Direction.Down;
                //UpdateShark(Direction.Down);
                _levelController.CurrentState = LevelController.TurnState.Water;
            }
            if (Input.GetKeyDown(KeyCode.A) && prevRotation == transform.rotation)
            {
                prevPosition.x -= speed;
                playerDirection = Direction.Left;
                //UpdateShark(Direction.Left);
                _levelController.CurrentState = LevelController.TurnState.Water;
            }
            if (Input.GetKeyDown(KeyCode.D) && prevRotation == transform.rotation)
            {
                prevPosition.x += speed;
                playerDirection = Direction.Right;
                //UpdateShark(Direction.Right);
                _levelController.CurrentState = LevelController.TurnState.Water;
            }

            prevRotation = transform.rotation;
            transform.position = prevPosition;
        }
    }

    void OnCollisionEnter (Collision col)
    {
        var tile = col.transform.tag;
        if (tile == "Water")
        {
            floorType = FloorType.Water;
        } else if( tile == "Floor")
        {
            floorType = FloorType.Floor;
        }

        UpdateShark(playerDirection);
    }

    void UpdateShark(Direction dir)
    {
        switch (dir)
        {
            case Direction.Right:
                if (floorType == FloorType.Water)
                {
                    Renderer.material = RightShark;
                }
                else if (floorType == FloorType.Floor)
                {
                    Renderer.material = RightLandShark;
                }
                break;
            case Direction.Left:
                if (floorType == FloorType.Water)
                {
                    Renderer.material = LeftShark;
                }
                else if (floorType == FloorType.Floor)
                {
                    Renderer.material = LeftLandShark;
                }
                break;
            case Direction.Up:
                if (floorType == FloorType.Water)
                {
                    Renderer.material = FrontShark;
                }
                else if (floorType == FloorType.Floor)
                {
                    Renderer.material = FrontLandShark;
                }
                break;
            case Direction.Down:
                if (floorType == FloorType.Water)
                {
                    Renderer.material = FrontShark;
                }
                else if (floorType == FloorType.Floor)
                {
                    Renderer.material = FrontLandShark;
                }
                break;
        }
    }
}
