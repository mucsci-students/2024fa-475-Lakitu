using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isOn;

    public GameObject door;
    public Vector3 opened;
    public Vector3 closed;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

        opened = new Vector3(-5.09f, 10f, -102.5951f);
        closed = new Vector3(-5.09f, 4f, -102.5951f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn){
            door.transform.position = opened;
        }
        else{
            door.transform.position = closed;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6){
            isOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 6){
            isOn = false;
        }
    }
}
