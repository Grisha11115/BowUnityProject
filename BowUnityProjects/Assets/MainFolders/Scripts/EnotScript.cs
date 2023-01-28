using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnotScript : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody Rigid;

    private TargetScript Target;
    public GameObject TargetMother;

    public float Speed = 0f;

    public bool BringTarget = false;

    private GameObject Targ;

    void Start()
    {
        Targ = GameObject.FindGameObjectWithTag("Target");
        Rigid = GetComponent<Rigidbody>();
        Target = TargetMother.GetComponent<TargetScript>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Target.isHit)
        {
            Target.isHit = false;
            Vector3 Dist = Targ.transform.position - transform.position;
            Rigid.velocity = Dist * Speed;
            transform.LookAt(Targ.transform.position);

            if (Rigid.velocity.magnitude > 0)
            {
                Anim.Play("Move");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Rigid.velocity = new Vector3(0,0,0);
            BringTarget = true;
            Target.NewPosition();
            int Sector = Random.Range(1, 5);
            Vector3 SpawnPos = new(0, 1, 0);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(Random.Range(20, 30), 1, Random.Range(20, 30));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(Random.Range(-20, -30), 1, Random.Range(20, 30));
                    SpawnPos = SpawnPos2;
                    break;
                case 3:
                    Vector3 SpawnPos3 = new(Random.Range(-20, -30), 1, Random.Range(-20, -30));
                    SpawnPos = SpawnPos3;
                    break;
                case 4:
                    Vector3 SpawnPos4 = new(Random.Range(20, 30), 1, Random.Range(-20, -30));
                    SpawnPos = SpawnPos4;
                    break;
            }
            Rigid.velocity = SpawnPos;
        }
    }

}
