using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyDiamondChase : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float speed = 5f;  // Speed of Tiny Diamond

    void Start()
    {
        if (player == null)
        {
            // Automatically find the player if not manually assigned
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (player != null)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Optional: Rotate to face the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}
