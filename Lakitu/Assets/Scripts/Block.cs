using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject player;
    public PlayerController ps;
    public GameObject invisibleObject;  // Reference to the invisible game object
    public bool isGrab;

    void Start()
    {
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerController>();
        isGrab = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TeleportToInvisibleObject();
        }

        // If the block is grabbed, it follows the player
        if (isGrab)
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = Vector3.Normalize(player.transform.forward) * 2 + player.transform.position;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // Function to teleport the block to the invisible object's position
    void TeleportToInvisibleObject()
    {
        if (invisibleObject != null)
        {
            transform.position = invisibleObject.transform.position;
        }
    }
}
