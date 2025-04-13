using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class MoveToPlayerAction : ActionNode
{
    public MoveToPlayerAction()
    {
        name = "Move To Player Action";

    }
    public override void Action()
    {
        //enter functionality for action
        if (Agent.GetComponent<Starship>().state != ActionState.MOVE_TO_PLAYER)
        {
            Debug.Log("starting " + name);
            Starship ss = Agent.GetComponent<Starship>();
            ss.state = ActionState.MOVE_TO_PLAYER;
            // custom enter actions 
        }
        //everyframe
        Debug.Log("Performing" + name);

    }
}