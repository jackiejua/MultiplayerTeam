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
        StartCoroutine(DisplayDialogueSequence());
    }

    IEnumerator DisplayDialogueSequence()
    {
        // Display initial dialogue
        dialogueText.text = "Fine, I'll get you myself.";
        yield return new WaitForSeconds(2); // Display for 2 seconds

        // Display timer
        float timer = 30f;
        while (timer > 0)
        {
            timerText.text = "Time remaining: " + timer.ToString("F1") + " seconds";
            yield return new WaitForSeconds(1);
            timer -= 1;
        }
        timerText.text = "";

        // Display final dialogue
        dialogueText.text = "Whatever, get out of here before I change my mind.";
    }
}
