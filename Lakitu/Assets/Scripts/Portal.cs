using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;  // The linked portal to teleport to
    public Vector3 teleportOffset = Vector3.zero;  // Adjustable offset for teleportation

    private bool isTeleporting = false;  // Prevent teleport loops

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered and teleportation is not happening already
        if (isTeleporting || linkedPortal == null) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the portal!");

            // Start the teleportation process
            StartCoroutine(TeleportPlayer(other));
        }
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        isTeleporting = true;
        linkedPortal.isTeleporting = true;  // Prevent teleport loop on the linked portal

        // Debugging: log linked portal details
        if (linkedPortal != null)
        {
            // Check and log both portal positions to make sure they are correctly assigned
            Debug.Log("Player will be teleported to linked portal's position: " + linkedPortal.transform.position);
            Debug.Log("Linked portal position: " + linkedPortal.transform.position);
            Debug.Log("Current portal position: " + transform.position);

            // Calculate the new position using the linked portal position and the offset
            Vector3 targetPosition = linkedPortal.transform.position + linkedPortal.transform.TransformDirection(teleportOffset);
            Debug.Log("Calculated target position: " + targetPosition);

            // Move the player to the calculated position
            player.transform.position = targetPosition;

            // Optionally rotate the player to match the linked portal's rotation
            player.transform.rotation = linkedPortal.transform.rotation;
        }
        else
        {
            Debug.LogError("Linked portal is not assigned!");
        }

        // Small delay to prevent teleport loops and ensure teleportation completes
        yield return new WaitForSeconds(0.1f);

        isTeleporting = false;
        linkedPortal.isTeleporting = false;
    }
}
