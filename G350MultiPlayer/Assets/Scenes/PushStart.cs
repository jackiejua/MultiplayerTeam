using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OfficePlayer : MonoBehaviour
{

     [SerializeField] private GameObject player;
      public InputActionReference cameraRotation;
      public InputActionReference AcceptMission;
    [SerializeField] private Camera playerCamera;
    public float cameraRotationSpeed = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MissionAccepted();
    }

       void RotateCamera()
    {
        Vector2 cameraInput = cameraRotation.action.ReadValue<Vector2>();
        float mouseX = cameraInput.x * cameraRotationSpeed * Time.deltaTime;
        float mouseY = cameraInput.y * cameraRotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
        playerCamera.transform.Rotate(Vector3.left, mouseY);
       
    }


    public void MissionAccepted()
    {
        if (AcceptMission.action.triggered)
        {
            SceneManager.LoadScene("VictimSceneOne");
        }
      
    }
}

