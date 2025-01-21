using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentObject : MonoBehaviour
{
    [SerializeField]

    Transform m_Target;
    public Vector3 TargetPosition
    { 
        get { return m_Target.position; }
        set { m_Target.position = value; }
    }
    // Start is called before the first frame update
     public void Start()
    {
        Debug.Log("Starting Agent....");
        TargetPosition = m_Target.position;
    }


}
