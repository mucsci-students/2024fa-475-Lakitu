using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public Transform playerStartPosition;
    public SpeedrunTimer speedrunTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {

                playerController.Teleport(playerStartPosition.position, playerStartPosition.rotation);
            }


       
        }
    }
}