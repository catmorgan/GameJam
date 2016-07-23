//using UnityEngine;
//using System.Collections;

//public class SharkMovement : MonoBehaviour
//{

//    //movement variables
//    public float walkSpeed = 10;
//    public float runSpeed = 12;
//    public float acceleration = 30;
//    public float gravity = 20;
//    public float jumpHeight = 12;
//    public float playerDirection;
//    public float doubleJump = 1;

//    private float currentSpeed;
//    private float targetSpeed;

//    private Vector2 movement;
//    //private PlayerPhysics physics;
//    private float timer = 3;

//    void Start()
//    {
//        //physics = GetComponent<PlayerPhysics>();
//    }

//    void Update()
//    {
//        //if player isn't moving		
//        if (physics.stopped)
//        {
//            targetSpeed = 0;
//            currentSpeed = 0;
//        }

//        float speed = (Input.GetButton("Run")) ? runSpeed : walkSpeed;
//        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
//        currentSpeed = moveTowards(currentSpeed, targetSpeed, acceleration);

//        //object is on the ground
//        //if (physics.grounded)
//        //{
//        //    movement.y = 0;
//        //    if (timer <= 0)
//        //    {
//        //        doubleJump = 1;
//        //        timer = 3;
//        //    }
//        //    else if (doubleJump == 0)
//        //    {
//        //        timer -= Time.deltaTime;
//        //    }

//        //    //jump
//        //    if (Input.GetButtonDown("Jump"))
//        //    {
//        //        movement.y = jumpHeight;
//        //    }
//        //}
//        //double jump
//        else if (Input.GetButtonDown("Jump") && doubleJump == 1)
//        {
//            movement.y += jumpHeight / 2;
//            doubleJump--;
//        }
//        //move the object at speed
//        movement.x = currentSpeed;
//        //apply gravity to the object
//        movement.y -= gravity * Time.deltaTime;
//        //move the object 
//        //physics.move(movement * Time.deltaTime);
//    }

//    //target to increment towards
//    private float moveTowards(float current, float target, float accel)
//    {
//        //we've reached out target
//        if (current == target)
//        {
//            return current;
//        }
//        else
//        {
//            //get the direction of current to target
//            playerDirection = Mathf.Sign(target - current);
//            //increment the current to be towards the target
//            current += playerDirection * accel * Time.deltaTime;
//            //if we're towards the target, return current, else we are away
//            //from target so return target
//            return (playerDirection == Mathf.Sign(target - current)) ? current : target;
//        }
//    }
//}
