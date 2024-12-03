using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        timerText.enabled = false;
        StartCoroutine(DisplayDialogueSequence());
    }

    IEnumerator DisplayDialogueSequence()
    {
        // Display initial dialogue
        dialogueText.text = "Diamond: Fine, I'll get you myself. RUN";
        yield return new WaitForSeconds(3); // Display for 2 seconds
        dialogueText.enabled = false;
        timerText.enabled = true;

        // Display timer
        float timer = 45f;
        while (timer > 0)
        {
            timerText.text = "Time: " + timer.ToString("F1") + "s";
            yield return new WaitForSeconds(1);
            timer -= 1;
        }
        timerText.text = "";

        // Display final dialogue
        dialogueText.enabled = true;
        dialogueText.text = "Whatever, get out of here before I change my mind.";
    }
}
