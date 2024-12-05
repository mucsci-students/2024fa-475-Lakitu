using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject player;
    public PlayerController ps;

    public bool isGrab;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerController>();
        isGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isGrab = !isGrab;
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
        }

        if(isGrab){
            transform.position = player.transform.position + new Vector3(0f, 5f, 0f);
        }
    }
}
