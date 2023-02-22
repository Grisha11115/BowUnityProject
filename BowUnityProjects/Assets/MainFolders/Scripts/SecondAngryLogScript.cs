using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SecondAngryLogScript : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform FirstAngryLog;
    public float LogHP = 100f;
    public Slider _Slider;
    public GameObject SliderMother;
    public FirstAngryLogScript EnotPobeg;
    public UIMeneger _UIMeneger;
    public GameObject Logs;
    public GameObject Player;
    void Update()
    {
        SliderMother.transform.LookAt(Player.transform.position);
        _Slider.value = LogHP * 0.01f;
        Agent.SetDestination(FirstAngryLog.position);
        if(LogHP <= 0)
        {
            StartCoroutine(TimerStart(5));
            _UIMeneger.NumOfStage = 4;
            this.gameObject.SetActive(false);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            collision.gameObject.SetActive(true);
            LogHP -= 33.4f;
        }
    }
    public IEnumerator TimerStart(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
