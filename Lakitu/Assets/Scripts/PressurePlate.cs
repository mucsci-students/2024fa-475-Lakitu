using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
