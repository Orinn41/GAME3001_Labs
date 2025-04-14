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
        if (Agent.GetComponent<AgentObject>().state != ActionState.MOVE_TO_PLAYER)
        {
            Debug.Log("starting " + name);
            AgentObject ao = Agent.GetComponent<AgentObject>();
            ao.state = ActionState.MOVE_TO_PLAYER;
            // custom enter actions
            if(AgentScript is CloseCombatEnemy cce)
            {

            }
        }
        //everyframe
        Debug.Log("Performing" + name);

    }
}