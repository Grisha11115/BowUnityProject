using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondAngryLogScript : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform FirstAngryLog;
    private void Start()
    {

    }
    void Update()
    {
        Agent.SetDestination(FirstAngryLog.position);
    }
}
