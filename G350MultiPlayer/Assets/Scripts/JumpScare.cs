using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    [SerializeField] private Image jumpScareImage; // Reference to the jumpscare image UI element

    // Start is called before the first frame update
    void Start()
    {
        jumpScareImage.gameObject.SetActive(false);
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
        jumpScareImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        jumpScareImage.gameObject.SetActive(false);
    }
}
