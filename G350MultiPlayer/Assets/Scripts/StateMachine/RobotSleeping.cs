using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotSleeping : RobotState
{
   public RobotSleeping(RobotStateController rsc) : base(rsc)
   {

   }

   public override void OnStateEnter()
   {
      rsc.scanner.GetComponent<Renderer>().material = rsc.blue;
   }

   public override void CheckTransitions()
   {
      if (rsc.player != null)
      {
         float dist = Vector3.Distance(rsc.transform.position, rsc.player.transform.position);
         if (dist < 5f)
         {
            rsc.SetState(new RobotWorking(rsc));
         }
      }
   }

   public override void Act()
   {
      rsc.GetComponent<NavMeshAgent>().isStopped = true;

   }

   public override void OnStateExit()
   {

   }
}
