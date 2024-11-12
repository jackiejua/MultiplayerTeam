using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pushStart : MonoBehaviour
{

       public InputActionReference StartGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beginGame();
    }

        public void beginGame()
    {
        if (StartGame.action.triggered)
        {
            SceneManager.LoadScene("Level1");
        }
      
    }
}
