using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstAngryLogScript : MonoBehaviour
{
    public Vector3 NewPos;
    public NavMeshAgent Agent;
    public float Stamina = 100f; 

    private int Sector = 2;
    public float PosY;

    public SecondAngryLogScript SecondLogScript;
    public GameObject SecondLog;
    void Start()
    {
        StartCoroutine(TimerStart(Stamina));
        NewPosition();
    }


    void Update()
    {
        Vector3 CurrentPos = new(transform.position.x, PosY, transform.position.z);
        Agent.SetDestination(NewPos);
        if(SecondLogScript.LogHP >= 0)
        {
            if (NewPos == CurrentPos)
            {
                NewPosition();
            }
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
                Vector3 SpawnPos2 = new(Random.Range(-25, -35), PosY, Random.Range(25, 35));
                NewPos = SpawnPos2;
                Sector = 4;
                break;
            case 3:
                Vector3 SpawnPos3 = new(Random.Range(-25, -30), PosY, Random.Range(5, 15));
                NewPos = SpawnPos3;
                Sector = 1;
                break;
            case 4:
                Vector3 SpawnPos4 = new(Random.Range(25, 35), PosY, Random.Range(5, 15));
                NewPos = SpawnPos4;
                Sector = 3;
                break;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            collision.gameObject.SetActive(true);
        }
    }
    public IEnumerator TimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        NewPos = new(0, PosY, 15);
        transform.rotation = Quaternion.LookRotation(Vector3.back);
        
    }
}
