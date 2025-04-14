using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class PatrolAction : ActionNode
{
    public PatrolAction()
    {
        name = "Patrol Action";

    }
    public override void Action()
    {
        //enter functionality for action
        if (Agent.GetComponent<Starship>().state != ActionState.PATROL)
        {
            Debug.Log("starting " + name);
            Starship ss = Agent.GetComponent<Starship>();
            ss.state = ActionState.PATROL;
            // custom enter actions 
            ss.StartPatrol();
        }
        //everyframe
        Debug.Log("Performing" + name);

    }
}
