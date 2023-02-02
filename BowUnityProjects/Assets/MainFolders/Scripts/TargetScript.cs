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

        int Sector = Random.Range(1, 3);
        Vector3 SpawnPos = new Vector3(0, 0, 0);
        switch (Sector)
        {
            case 1:
                Vector3 SpawnPos1 = new Vector3(Random.Range(0, 14), 1.5f, Random.Range(7, 43));
                SpawnPos = SpawnPos1;
                break;
            case 2:
                Vector3 SpawnPos2 = new Vector3(Random.Range(-14, 0), 1.5f, Random.Range(7, 43));
                SpawnPos = SpawnPos2;
                break;
        }
        transform.position = SpawnPos;

    }

}
