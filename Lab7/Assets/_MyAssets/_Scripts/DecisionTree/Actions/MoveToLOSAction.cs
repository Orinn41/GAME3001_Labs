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
        if(Agent.GetComponent<AgentObject>().state != ActionState.MOVE_TO_LOS)
        {
            Debug.Log("starting " + name);
            AgentObject ao = Agent.GetComponent<AgentObject>();
            ao.state = ActionState.MOVE_TO_LOS;
            // custom enter actions 
            if (AgentScript is CloseCombatEnemy cce)
            {

            }
            else if (AgentScript is RangedCombatEnemy rce)
            {
               
            }
        }
        //everyframe
        Debug.Log("Performing" +name);
    }
}
