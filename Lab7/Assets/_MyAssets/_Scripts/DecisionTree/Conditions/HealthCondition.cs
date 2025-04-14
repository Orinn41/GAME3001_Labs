using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fill in for Lab 7a.
public class HealthCondition : ConditionNode
{
    public bool IsHealthy { get; set; }

    public HealthCondition()
    {
        name = "Close Combat Range Condition";
        IsHealthy = false;
    }
    public override bool Condition()
    {
        Debug.Log("Checking " +  name);
        // Do the Checking condition stuff
        return IsHealthy;
    }
}
