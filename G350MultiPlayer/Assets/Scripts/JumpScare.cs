using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject jumpScareImage; // Reference to the jumpscare image UI element

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayJumpScare());
        }
    }

    IEnumerator DisplayJumpScare()
    {
        jumpScareImage.SetActive(true);
        yield return new WaitForSeconds(2);
        jumpScareImage.SetActive(false);
    }
}
