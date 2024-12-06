using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject player;
    public PlayerController ps;

    public Ray ray;

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
        if(isGrab){
            GetComponent<Rigidbody>().useGravity = false;
            
            transform.position = Vector3.Normalize(player.transform.forward) * 2 + player.transform.position;
        }
        else{
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
