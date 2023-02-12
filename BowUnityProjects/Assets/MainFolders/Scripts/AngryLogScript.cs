using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstAngryLogScript : MonoBehaviour
{
    private Vector3 NewPos;
    public NavMeshAgent Agent;

    private int Sector = 2;
    private float PosY;
    void Start()
    {
        NewPosition();
    }


    void Update()
    {
        Vector3 CurrentPos = new(transform.position.x, PosY, transform.position.z);
        Agent.SetDestination(NewPos);
        if (NewPos == CurrentPos)
        {
            NewPosition();
        }

    }
    private void NewPosition()
    {
        switch (Sector)
        {
            case 1:
                Vector3 SpawnPos1 = new(Random.Range(30, 35), PosY, Random.Range(25, 35));
                NewPos = SpawnPos1;
                Sector = 2;
                break;
            case 2:
                Vector3 SpawnPos2 = new(Random.Range(-30, -35), PosY, Random.Range(25, 35));
                NewPos = SpawnPos2;
                Sector = 1;
                break;
        }

    }
}
