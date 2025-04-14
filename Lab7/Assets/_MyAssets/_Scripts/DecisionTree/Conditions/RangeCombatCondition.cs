using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class RangeCombatCondition : ConditionNode
{
    public bool ISWithinCombatRange { get; set; }

    public RangeCombatCondition()
    {
        name = "Ranged Combat  Condition";
        ISWithinCombatRange = false;
    }
    public override bool Condition()
    {
        Debug.Log("Checking " +  name);
        // Do the Checking condition stuff
        return ISWithinCombatRange;
    }
}
