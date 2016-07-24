using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
    public LayerMask myLayerMask;

    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        float rayDistance;
        Collider rayHitObject;
        

        //Debug make the ray visible
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 2;
        Debug.DrawRay(transform.position,forward,Color.red);


        if (Physics.Raycast(transform.position, (forward), out hit, myLayerMask))
        {
            rayDistance = hit.distance;
            rayHitObject = hit.collider;
            print("RayHit Object is " + rayHitObject);
            
            print(rayDistance + " " + hit.collider.gameObject.name);

            //what did we hit?
            
            if (hit.collider.tag == "Boxes" || hit.collider.tag == "Wall")
            {
                if (hit.distance == 1)
                {
                    //bad normal move 
                    //return false;
                    print("bad normal Move");
                }
                else
                {
                    //bad lunge move
                    print("bad lunge move");
                }
            }
            else
            {
                //Good Move
                print("Good Move");
            }

        }
    }
}
