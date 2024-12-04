using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyCollect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI candyText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject door;
    

    private int candyCount;

    // Start is called before the first frame update
    void Start()
    {
     //   candyCount = 0;
       
        candyText.text = "Candy: not found" ;
        //    UpdateCandyText();
        
        levelText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            candyCount++;
            UpdateCandyText();
            

            if (candyCount >= 1)
            {
               
               Destroy(door);
               levelText.enabled = true;
               levelText.text = "Level Complete! Door is now open!";
               candyText.text = "Candy: Collected!" ;
             //   StartCoroutine(RotateDoor());
            }

            
            Destroy(gameObject);
        }
    }

    void UpdateCandyText()
    {
        candyText.text = "Candy: Collected!" ;
    }

    IEnumerator RotateDoor()
    {
        Quaternion startRotation = door.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 90, 0);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
    }
}
