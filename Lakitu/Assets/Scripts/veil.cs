using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veil : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public bool isOn;
    public Vector3 offscreen;
    void Start()
    {
        isOn = false;
        offscreen = new Vector3(100f, 100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn){
            transform.position = player.transform.position;
        }
        else{
            transform.position = offscreen;
        }
    }
}
