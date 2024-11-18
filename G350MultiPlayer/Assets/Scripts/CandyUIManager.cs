
using UnityEngine;
using UnityEngine.UI;

public class CandyUIManager : MonoBehaviour
{
    public Text candyText;

    public void UpdateCandyText(int candyCount)
    {
        candyText.text = "Candy: " + candyCount.ToString();
    }
}