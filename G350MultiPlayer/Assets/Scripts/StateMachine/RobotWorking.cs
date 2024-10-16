using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotWorking : RobotState
{
    public RobotWorking(RobotStateController rsc) : base(rsc)
    {

    }

    public override void OnStateEnter()
    {
        rsc.scanner.GetComponent<Renderer>().material = rsc.red;
        rsc.GetComponent<NavMeshAgent>().isStopped = false;
    }

    public override void CheckTransitions()
    {
        if (rsc.player == null)
        {
            rsc.SetState(new RobotSleeping(rsc));
        }
        else
        {
            rsc.scanner.transform.LookAt(rsc.player.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(rsc.scanner.transform.position, rsc.scanner.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.name != rsc.player.name)
                {
                    rsc.SetState(new RobotSleeping(rsc));
                }
            }
        }
    }

    public override void Act()
    {
        float dist = Vector3.Distance(rsc.transform.position, rsc.currentDestination.position);
        if (dist < 3f)
        {
            rsc.currentDestination = rsc.RandomDestination();
        }

        rsc.robot.SetDestination(rsc.currentDestination.position);
    }

    public override void OnStateExit()
    {

    }
}
