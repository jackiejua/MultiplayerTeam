using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int numberOfPlayers = 0;

    public int CheckTotalPlayers()
    {
        return numberOfPlayers;
    }

    public void AddPlayer()
    {
        numberOfPlayers++;
    }
}
