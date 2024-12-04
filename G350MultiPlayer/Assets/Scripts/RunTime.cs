using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class RunTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject tiny;
    [SerializeField] private GameObject door;


    void Start()
    {
        timerText.enabled = false;
        StartCoroutine(DisplayDialogueSequence());
    }

    IEnumerator DisplayDialogueSequence()
    {
        // Display initial dialogue
        dialogueText.text = "Diamond: Fine, I'll get you myself. RUN";
        yield return new WaitForSeconds(3); // Display for 3 seconds
        dialogueText.enabled = false;
        timerText.enabled = true;

        // Display timer
        float timer = 30f;
        while (timer > 0)
        {
            timerText.text = "Time: " + timer.ToString("F1") + "s";
            yield return new WaitForSeconds(1);
            timer -= 1;
        }
        timerText.text = "";

        // Destroy tiny when timer hits 0
        Destroy(tiny);
        Destroy(door);

        // Display final dialogue
        dialogueText.enabled = true;
        dialogueText.text = "Whatever, get out of here before I change my mind.";
    }
}
