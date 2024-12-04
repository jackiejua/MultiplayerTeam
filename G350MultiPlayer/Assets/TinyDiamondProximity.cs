using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class TinyDiamondProximity : MonoBehaviour
{
    public float activationDistance = 10f;  // Distance to activate the chase
    public float stopDistance = 15f;       // Distance to stop chasing and switch targets
    public float speed = 5f;               // Speed of Tiny Diamond
    public float chaseDuration = 30f;      // Time to chase before disappearing

    private Transform currentTarget;       // The player Tiny Diamond is currently chasing
    private float chaseTimer = 0f;         // Timer to track how long Tiny Diamond has been chasing
    private bool isChasing = false;        // Whether Tiny Diamond is chasing a player

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            FindClosestPlayer();
        }
    }

    private void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Find all players
        float shortestDistance = Mathf.Infinity;
        Transform nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < shortestDistance && distance <= activationDistance)
            {
                shortestDistance = distance;
                nearestPlayer = player.transform;
            }
        }

        if (nearestPlayer != null)
        {
            currentTarget = nearestPlayer;
            StartChasing();
        }
    }

    private void StartChasing()
    {
        isChasing = true;
        chaseTimer = 0f; // Reset the timer
        Debug.Log("Tiny Diamond is chasing a player!");
    }

    private void ChasePlayer()
    {
        if (currentTarget == null)
        {
            StopChasing();
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

        // Switch targets if another player is closer
        if (distanceToTarget > stopDistance)
        {
            StopChasing();
            return;
        }

        // Move towards the current target
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Rotate to face the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        // Update chase timer
        chaseTimer += Time.deltaTime;
        if (chaseTimer >= chaseDuration)
        {
           // Disappear();
        }
    }

    private void StopChasing()
    {
        Debug.Log("Tiny Diamond stopped chasing.");
        isChasing = false;
        currentTarget = null; // Reset the target
    }

    private void Disappear()
    {
        Debug.Log("Tiny Diamond disappeared!");
        Destroy(gameObject); // Remove Tiny Diamond from the scene
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tiny Diamond hit a player! Game Over.");
            SceneManager.LoadScene("Died"); // Load the "Died" scene
        }
    }
}




