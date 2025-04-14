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
        if (Agent.GetComponent<AgentObject >().state != ActionState.PATROL)
        {
            Debug.Log("starting " + name);
            AgentObject ao = Agent.GetComponent<AgentObject>();
            ao.state = ActionState.PATROL;
            // custom enter actions 
            if(AgentScript is CloseCombatEnemy cce)
            {
                cce.StartPatrol();
            }
            else if (AgentScript is RangedCombatEnemy rce)
            {
                rce.StartPatrol();
            }
        }
        //everyframe
        Debug.Log("Performing" + name);

    }
}
