using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class FleeAction : ActionNode
{
    public FleeAction()
    {
        name = "Flee Action";
    }
    public override void Action()
    {
        // enter functionality for action 
        if(Agent.GetComponent<AgentObject>().state != ActionState.FLEE)
        {
            Debug.Log("Starting " + name);
            AgentObject ao = Agent.GetComponent<AgentObject>();
            ao.state = ActionState.FLEE;
            //custom enter actions 
            if(AgentScript is RangedCombatEnemy rce)
            {

            }

        }
        Debug.Log("Performing " + name);
    }
}
