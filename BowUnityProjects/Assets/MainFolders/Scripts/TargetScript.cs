using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetScript : MonoBehaviour
{
    public UIMeneger UIManager;
    public GameObject TargetMotherUIManager;

    [SerializeField] private GameObject EmptyArrowTargTag;

    public bool isHit = false;

    private GameObject[] ArrowArray;


    private void Start()
    {
        UIManager = TargetMotherUIManager.GetComponent<UIMeneger>();
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
            Instantiate(EmptyArrowTargTag, ArrowPos, collision.transform.rotation);
            collision.gameObject.SetActive(false);
        }
    }
    public void NewPosition()
    {

        int Sector = UnityEngine.Random.Range(1, 3);
        Vector3 SpawnPos = new Vector3(0, 0, 0);
        switch (Sector)
        {
            case 1:
                Vector3 SpawnPos1 = new Vector3(UnityEngine.Random.Range(0, 14), 50, UnityEngine.Random.Range(7, 43));
                SpawnPos = SpawnPos1;
                break;
            case 2:
                Vector3 SpawnPos2 = new Vector3(UnityEngine.Random.Range(-14, 0), 50, UnityEngine.Random.Range(7, 43));
                SpawnPos = SpawnPos2;
                break;
        }
        transform.position = SpawnPos;
        ArrowArray = GameObject.FindGameObjectsWithTag("ArrowOnTarget");
        foreach (GameObject element in ArrowArray)
        {
            Destroy(element);
        }

    }


}
