
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCandyCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI candyText;
    private int candyCount;

    // Start is called before the first frame update
    void Start()
    {
        candyCount = 0;
        UpdateCandyText();
    }

    public void CollectCandy()
    {
        candyCount++;
        UpdateCandyText();
    }

    void UpdateCandyText()
    {
        candyText.text = "Candy: " + candyCount.ToString();
    }
}