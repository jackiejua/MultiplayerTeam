using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WeDied : MonoBehaviour

{

       public InputActionReference RetryGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

        public void RestartGame()
    {
        if (RetryGame.action.triggered)
        {
            SceneManager.LoadScene("Level1");
        }
      
    }
}