using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    private float StartTime;
    private GameObject controller;

    private void OnEnable()
    {
        controller = GameObject.Find("Controller");
        StartTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - StartTime > 5f)
        {
            ReturnObjectToPool();
        }
    }

    private void ReturnObjectToPool()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        controller.GetComponent<ObjectPool>().ReturnObjectToPool(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().ShootingScoreIncreased();
            ReturnObjectToPool();
        }
        else
        {
            ReturnObjectToPool();
        }
    }
}
