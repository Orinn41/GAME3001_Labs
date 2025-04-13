using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class LOSCondition : ConditionNode
{
    public bool hasLOS { get; set; }

    public LOSCondition()
    {
        name = "LOS Condition";
        hasLOS = false;
    }
    public override bool Condition()
    {
        Debug.Log("Checking " + name);
        // Do the Checking condition stuff
        return hasLOS;
    }
}
