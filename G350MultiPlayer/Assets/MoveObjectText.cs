using UnityEngine;
using UnityEngine.UI; // For handling UI Text

public class MoveObjectText : MonoBehaviour
{
    [SerializeField] private GameObject instructionTextUI;  // Reference to the UI text to show instructions
    [SerializeField] private float interactionDistance = 3f;  // How close the player must be to the object to see the text

    private void Start()
    {
        // Initially hide the instruction text
        instructionTextUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction area
        if (other.CompareTag("Player"))  // Assuming the player has the "Player" tag
        {
            // Show the instruction text when the player is near
            instructionTextUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Hide the instruction text when the player moves away
        if (other.CompareTag("Player"))
        {
            instructionTextUI.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere in the editor to visualize the interaction range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
