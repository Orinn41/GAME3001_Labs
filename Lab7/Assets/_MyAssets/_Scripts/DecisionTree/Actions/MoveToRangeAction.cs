using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class MoveToRangeAction : ActionNode
{
    public MoveToRangeAction()
    {
        name = "Move to Range Action";
    }
    public override void Action()
    {
        // enter functionality for action 
        if(Agent.GetComponent<AgentObject>().state != ActionState.MOVE_TO_RANGE)
        {
            Debug.Log("Starting " + name);
            AgentObject ao = Agent.GetComponent<AgentObject>();
            ao.state = ActionState.MOVE_TO_RANGE;
            //custom enter actions 
            if(AgentScript is RangedCombatEnemy rce)
            {

            }

        }
        Debug.Log("Performing " + name);
    }
}
