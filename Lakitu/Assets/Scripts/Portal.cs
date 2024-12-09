using UnityEngine;
using System.Collections;
using System.Collections.Generic;





public class Portal : MonoBehaviour
{
    public Transform teleportTarget; // The location to teleport the player to
    public float portalCooldown = 2f; // Cooldown duration in seconds

    private bool isCooldownActive = false; // Flag to track cooldown state

    private void OnTriggerEnter(Collider other)
    {
        if (teleportTarget == null)
        {
            Debug.LogWarning("Teleport target not assigned.");
            return;
        }

        // Check if the object entering is the player
        if (other.CompareTag("Player") || other.GetComponent<Rigidbody>() != null)
        {
            // Check if the portal is in cooldown
            if (isCooldownActive)
                return;

            Debug.Log("Teleporting object to fixed location: " + teleportTarget.position);

            // Get the PlayerController component
            PlayerController playerController = other.GetComponent<PlayerController>();

            // Teleport the player to the target location
            if (playerController != null)
            {
                playerController.Teleport(teleportTarget.position, teleportTarget.rotation);
            }

            // Start the cooldown
            StartCoroutine(PortalCooldown());
        }
    }

    private IEnumerator PortalCooldown()
    {
        isCooldownActive = true;
        yield return new WaitForSeconds(portalCooldown);
        isCooldownActive = false;
    }
}
