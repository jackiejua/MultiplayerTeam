using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private InputActionReference P1ControllerPress;
    [SerializeField] private InputActionReference P2ControllerPress;

    private bool isP1Dragging;
    private bool isP2Dragging;
    private bool isBeingCarried;

    private void Awake()
    {
        // Enable Input Actions for Player 1 and Player 2
        P1ControllerPress.action.Enable();
        P2ControllerPress.action.Enable();

        // Set up Input Actions for Player 1
        P1ControllerPress.action.performed += _ => { isP1Dragging = true; CheckIfBothPlayersPress(); };
        P1ControllerPress.action.canceled += _ => { isP1Dragging = false; CheckDragEnd(); };

        // Set up Input Actions for Player 2
        P2ControllerPress.action.performed += _ => { isP2Dragging = true; CheckIfBothPlayersPress(); };
        P2ControllerPress.action.canceled += _ => { isP2Dragging = false; CheckDragEnd(); };
    }

    private void Update()
    {
        if (isP1Dragging && isP2Dragging)
        {
            if (!isBeingCarried)
            {
                StartDrag();
            }
            Drag();
        }
    }

    private void StartDrag()
    {
        isBeingCarried = true;
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void Drag()
    {
      
        Vector3 p1ControllerPos = GetPlayerControllerPosition(P1ControllerPress);
        Vector3 p2ControllerPos = GetPlayerControllerPosition(P2ControllerPress);

        Vector3 targetPosition = (p1ControllerPos + p2ControllerPos) / 2;
        transform.position = targetPosition;
    }

    private Vector3 GetPlayerControllerPosition(InputActionReference playerAction)
    {
      
        return new Vector3(playerAction.action.ReadValue<Vector2>().x, 0, playerAction.action.ReadValue<Vector2>().y);
    }

    private void CheckIfBothPlayersPress()
    {
        // Start dragging only if both players press the button simultaneously
        if (isP1Dragging && isP2Dragging)
        {
            StartDrag();
        }
    }

    private void CheckDragEnd()
    {
        if (!isP1Dragging && !isP2Dragging)
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        isBeingCarried = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
