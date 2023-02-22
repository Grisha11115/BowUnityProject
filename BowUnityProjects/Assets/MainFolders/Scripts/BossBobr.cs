using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossBobr : MonoBehaviour
{
    public float BobrHP = 100f;
    public float damage = 25f;
    private BowScript _BowScript;
    public GameObject MotherBowScript;
    public Transform Player;
    public Slider slider;
    public NavMeshAgent Agent;

    public GameObject UIMenagerObject;
    private UIMeneger _UIMeneger;


    void Start()
    {
        _BowScript = MotherBowScript.GetComponent<BowScript>();
        _UIMeneger = UIMenagerObject.GetComponent<UIMeneger>();
    }


    void Update()
    {
        if (BobrHP <= 0)
        {
            try
            {
                Destroy(this.gameObject);
                _UIMeneger.YouWinner();
            }
            catch(UnassignedReferenceException)
            {
            }
        }
        slider.value = BobrHP * 0.01f;
        Agent.SetDestination(Player.transform.position);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            BobrHP -= damage;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            _UIMeneger.YouLoser();
        }
    }


}
