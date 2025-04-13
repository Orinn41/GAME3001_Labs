using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class AttackAction : ActionNode
{
    public AttackAction()
    {
        name = "Attack Action";
    }
    public override void Action()
    {
        // enter functionality for action 
        if(Agent.GetComponent<Starship>().state != ActionState.ATTACK)
        {
            Debug.Log("Starting " + name);
            Starship ss = Agent.GetComponent<Starship>();
            ss.state = ActionState.ATTACK;
            //custom enter actions 

        }
        Debug.Log("Performing " + name);
    }
}
