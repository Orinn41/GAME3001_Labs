using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class MoveToLOSAction : ActionNode
{
    public MoveToLOSAction()
    {
        name = "Move To LOS Action";

    }
    public override void Action()
    {
        //enter functionality for action
        if(Agent.GetComponent<Starship>().state != ActionState.MOVE_TO_LOS)
        {
            Debug.Log("starting " + name);
            Starship ss = Agent.GetComponent<Starship>();
            ss.state = ActionState.MOVE_TO_LOS;
            // custom enter actions 
        }
        //everyframe
        Debug.Log("Performing" +name);
    }
}
