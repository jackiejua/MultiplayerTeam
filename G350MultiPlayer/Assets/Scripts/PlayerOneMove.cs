using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private bool isJumping = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = -transform.right * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 movement = -transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = transform.right * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movement = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }

        if (Input.GetKeyDown(KeyCode.C) && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}

