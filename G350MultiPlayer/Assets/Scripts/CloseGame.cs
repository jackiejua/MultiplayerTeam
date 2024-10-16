using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseGame : MonoBehaviour
{
     public InputActionReference closeGame;
 
    void Update()
    {
        if(closeGame.action.triggered)
        {
            Application.Quit();
        }
    }
}
