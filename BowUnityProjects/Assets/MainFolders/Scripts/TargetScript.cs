using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private EnotScript Enot;
    public GameObject EnotMother;

    [SerializeField] private GameObject EmptyArrow;
    public bool isHit = false;


    private void Start()
    {
        Enot = EnotMother.GetComponent<EnotScript>();
    }

    private void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            isHit = true;
            Vector3 ArrowPos = collision.contacts[0].point;
            Instantiate(EmptyArrow, ArrowPos, collision.transform.rotation);
            collision.gameObject.SetActive(false);



        }
    }
    public void NewPosition()
    {
        if (Enot.BringTarget)
        {
            int Sector = Random.Range(1, 5);
            Vector3 SpawnPos = new Vector3(0, 0, 0);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new Vector3(Random.Range(5, 17), 1, Random.Range(5, 17));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new Vector3(Random.Range(-5, -17), 1, Random.Range(5, 17));
                    SpawnPos = SpawnPos2;
                    break;
                case 3:
                    Vector3 SpawnPos3 = new Vector3(Random.Range(-5, -17), 1, Random.Range(-5, -17));
                    SpawnPos = SpawnPos3;
                    break;
                case 4:
                    Vector3 SpawnPos4 = new Vector3(Random.Range(5, 17), 1, Random.Range(-5, -17));
                    SpawnPos = SpawnPos4;
                    break;
            }

            transform.position = SpawnPos;
        }
    }

}
