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
	public LayerMask myLayerMask;
	private string hitObject;
	private string lastTurnHitObject;
	private bool turn = true;
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
		speed = FloorTile.localScale.x;
		Renderer = GetComponent<Renderer>();
		_levelController = GameObject.Find("Main Camera").GetComponent<LevelController>();
	}

	void Update() {
		//		bool test = checkRaycast ();
		//		print(test);

		//Lose a turn on land
		if (_levelController.CurrentState == LevelController.TurnState.Player && floorType == FloorType.Floor)
		{
			StartCoroutine("LoseATurn");
			_levelController.CurrentState = LevelController.TurnState.Water;
		}

		if (_levelController.CurrentState == LevelController.TurnState.Player) 
		{

			//DIRECTION
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
				UpdateShark (Direction.Up);
			}
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
				transform.rotation = Quaternion.Euler (0, 180, 0);
				UpdateShark (Direction.Down);
			}

			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.rotation = Quaternion.Euler (0, -90, 0);
				UpdateShark (Direction.Left);

			}
			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.rotation = Quaternion.Euler (0, 90, 0);
				UpdateShark (Direction.Right);

			}
			//MOVEMENT
			if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) && prevRotation == transform.rotation) 
			{
				if (checkRaycast ()) {
					prevPosition.z += speed;

					playerDirection = Direction.Up;
					//UpdateShark(Direction.Up);

					if (checkLastTurn ()) {
						_levelController.CurrentState = LevelController.TurnState.Water;
					}
				}

			}
			if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) && prevRotation == transform.rotation) 
			{
				if (checkRaycast ()) {
					prevPosition.z -= speed;
					playerDirection = Direction.Down;
					//UpdateShark(Direction.Down);
					if (checkLastTurn ()) {
						_levelController.CurrentState = LevelController.TurnState.Water;
					}
				}
			}
			if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) && prevRotation == transform.rotation) 
			{
				if (checkRaycast ()) {
					prevPosition.x -= speed;
					playerDirection = Direction.Left;
					//UpdateShark(Direction.Left);
					if (checkLastTurn ()) {
						_levelController.CurrentState = LevelController.TurnState.Water;
					}
				}
			}
			if ((Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) && prevRotation == transform.rotation) {
				if (checkRaycast ()) {
					prevPosition.x += speed;
					playerDirection = Direction.Right;
					//UpdateShark(Direction.Right);
					if (checkLastTurn ()) {
						_levelController.CurrentState = LevelController.TurnState.Water;
					}
				}
			}

			prevRotation = transform.rotation;
			transform.position = prevPosition;
		}
	}

	IEnumerator LoseATurn()
	{
		print ("About to wait 3 seconds");
		yield return new WaitForSeconds(3);
	}


	void OnCollisionEnter (Collision col)
	{
		var tile = col.transform.tag;
		<<<<<<< HEAD
		print ("current tile is " + tile);
		=======
		>>>>>>> origin/master
		if (tile == "Water")
		{
			floorType = FloorType.Water;
			print ("Floor type is " + floorType);
			lastTurnHitObject = "Water";
		} else if( tile == "Floor")
		{
			floorType = FloorType.Floor;
			print ("Floor type is " + floorType);
			lastTurnHitObject = "Floor";
		}

		UpdateShark(playerDirection);
	}

	bool checkLastTurn(){


		if ((lastTurnHitObject == "Water" && turn == true) || (lastTurnHitObject == "Floor" && turn == true)) {

			turn = false;
			print ("Last turn hit object was " + lastTurnHitObject);
			print ("turn is " + turn);
			print ("_________");
			return true;
		}
		else
			turn = true;
		print ("Last turn hit object was " + lastTurnHitObject);
		print ("turn is " + turn);
		print ("_________");
		return false;

	}


	bool checkRaycast()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, out hit, 1)) 
		{
			Debug.DrawRay (transform.position, fwd, Color.red);

			hitObject = hit.collider.tag;

			<<<<<<< HEAD
			//			print ("hit distance is " + hit.distance);
			//			print ("hit object is " + hitObject);
			=======
			>>>>>>> origin/master
			//		print (hit.collider.tag);


			<<<<<<< HEAD
			if (hitObject == "Floor" || hitObject == "Water" || hitObject == "Torpedos"){
				=======
				if (hitObject == "Floor" || hitObject == "Water" 
					|| hitObject == "Torpedos" || hitObject == "Sailor")
					>>>>>>> origin/master
					return true;
			}
			else
				return false;
		}

		else
			return false;
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
