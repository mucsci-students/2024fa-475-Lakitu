using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject veil;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            veil.GetComponent<veil>().isOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player"){
            veil.GetComponent<veil>().isOn = false;
        }
    }
}

