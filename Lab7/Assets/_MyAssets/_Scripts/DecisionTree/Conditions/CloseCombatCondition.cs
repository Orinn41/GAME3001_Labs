using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class CloseCombatCondition : ConditionNode
{
    public bool ISWithinCombatRange { get; set; }

    public CloseCombatCondition()
    {
        name = "Close Combat Range Condition";
        ISWithinCombatRange = false;
    }
    public override bool Condition()
    {
        Debug.Log("Checking " +  name);
        // Do the Checking condition stuff
        return ISWithinCombatRange;
    }
}
