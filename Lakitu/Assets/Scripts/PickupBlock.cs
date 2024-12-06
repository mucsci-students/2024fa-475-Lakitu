using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Ray ray;

    public GameObject empty;
    public GameObject box;

    public bool grabbing;

    // Start is called before the first frame update
    void Start()
    {
        grabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if(!grabbing){
                ray = new Ray(transform.position, transform.forward);   
                box = CheckForColliders();
                if (box.layer == 6){
                    grabbing = true;
                    box.GetComponent<Block>().isGrab = true;
                    box.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                }
            }
            else{
                grabbing = false;
                box.GetComponent<Block>().isGrab = false;
                box.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                box = empty;
            }
        }
        
    }
    GameObject CheckForColliders(){
        if(Physics.Raycast(ray, out RaycastHit hit)){
            return hit.collider.gameObject;
        }
        else{
            return empty;
        }
    }
}
