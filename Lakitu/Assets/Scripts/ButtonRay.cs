using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRay : MonoBehaviour
{
    public Ray ray;

    public GameObject empty;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            ray = new Ray(transform.position, transform.forward);   
            button = CheckForColliders();
            if (button.layer == 7){
                    button.transform.parent.gameObject.GetComponent<Numbers>().num =
                        (button.transform.parent.gameObject.GetComponent<Numbers>().num + 1) % 10;
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
