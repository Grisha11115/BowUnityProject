using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnotScript : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody Rigid;
    public NavMeshAgent Agent;

    private TargetScript Target;
    public GameObject TargetMother;

    public UIMeneger UIManager;
    public GameObject TargetMotherUIManager;
    public Transform Player;

    private Vector3 SpawnPos = new(0, 1.5f, 0);
    private bool GoingToSpawn = false;
    private bool GoingToTarg = false;

    private bool EnotTakeTarget = false;
    public int Timer;

    public float Speed = 0f;

    private float PosY;

    void Start()
    {
        UIManager = TargetMotherUIManager.GetComponent<UIMeneger>();
        Rigid = GetComponent<Rigidbody>();
        Target = TargetMother.GetComponent<TargetScript>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Timer++;
        Move();
        if (EnotTakeTarget)
        {
            if (Timer >= 60)
            {
                GoingToSpawn = true;
                EnotTakeTarget = false;
            }
        }
        Vector3 CurrentPosition = new(this.transform.position.x, PosY, this.transform.position.z);
        if (SpawnPos == CurrentPosition && GoingToSpawn)
        {
            Agent.speed = 0f;
        }
        if (Agent.speed >= 0)
        {
            Anim.SetBool("Move", true);

        }
        if (Agent.speed <= 0)
        {
            Anim.SetBool("Move", false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            UIManager.ScoreOfTarget++;
            Timer = 0;
            GoingToTarg = false;
            EnotTakeTarget = true;
            int Sector = Random.Range(1, 3);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(Random.Range(25, 35), PosY, Random.Range(25, 35));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(Random.Range(-25, -35), PosY, Random.Range(25, 35));
                    SpawnPos = SpawnPos2;
                    break;
            }
            Target.NewPosition();
       

        }
    }
    private void Move()
    {
        if (GoingToTarg)
        {
            Rigid.transform.LookAt(TargetMother.transform.position);
            Agent.speed = 7f;
            Agent.SetDestination(TargetMother.transform.position);
        }
        if (GoingToSpawn)
        {
            Rigid.transform.LookAt(SpawnPos);
            Agent.speed = 4f;
            Agent.SetDestination(SpawnPos);
        }
        if (Target.isHit)
        {
            GoingToSpawn = false;
            GoingToTarg = true;
            Target.isHit = false;
        }
    }


    
}
