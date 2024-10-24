using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotStateController : MonoBehaviour
{
    public GameObject player;
    public GameObject scanner;
    public RobotState currentState;
    public List<Transform> destinations = new List<Transform>();
    public NavMeshAgent robot;
    public Transform currentDestination;
    public Material red;
    public Material blue;


    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<NavMeshAgent>();
        currentDestination = RandomDestination();
        SetState(new RobotWorking(this));
    }

    public Transform RandomDestination()
    {
        if(destinations.Count > 0)
        {
            int rd = Random.Range(0, destinations.Count);
            return destinations[rd];
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.CheckTransitions();
        currentState.Act();
    }

    public void SetState(RobotState rs)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = rs;

        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
    }
}
