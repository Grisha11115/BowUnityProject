using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnotScript : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody Rigid;

    private TargetScript Target;
    public GameObject TargetMother;

    public NavMeshAgent Agent;

    private Vector3 SpawnPos = new(0, 1.5f, 0);
    private bool GoingToSpawn = false;
    private bool GoingToTarg = false;
    public int Timer;

    public float Speed = 0f;

    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Target = TargetMother.GetComponent<TargetScript>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Timer++;
        if (GoingToTarg)
        {
            Agent.speed = 7f;
            Agent.SetDestination(TargetMother.transform.position);
        }
        if(GoingToSpawn)
        {
            Agent.speed = 4f;
            Agent.SetDestination(SpawnPos);
        }
        if (Target.isHit)
        {
            GoingToSpawn = false;
            GoingToTarg = true;
            Target.isHit = false;
          //  if (Rigid.velocity.magnitude > 0)
           // {
           //     Anim.Play("Move");
           // }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Timer = 0;
            GoingToTarg = false;
            GoingToSpawn = true;
            Target.NewPosition();
            int Sector = Random.Range(1, 3);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(Random.Range(25, 35), 1.5f, Random.Range(25, 35));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(Random.Range(-25, -35), 1.5f, Random.Range(25, 35));
                    SpawnPos = SpawnPos2;
                    break;
            }
        }
    }
}
