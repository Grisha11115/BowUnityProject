using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBallonScript : MonoBehaviour
{
    public UIMeneger AirBallon_UI;
    public GameObject AirBallonMotherUIManager;
    private int Timer;
    private bool TimerIsOn;

    Vector3 SpawnPos = new(0, 1.5f, 20);


    private void Start()
    {
        AirBallon_UI = AirBallonMotherUIManager.GetComponent<UIMeneger>();
    }
    private void FixedUpdate()
    {


    }
    void Update()
    {
        if(transform.position.y >= 20)
        {
            int Sector = Random.Range(1, 3);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(10, -1.5f, Random.Range(15, 40));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(-10, -1.5f, Random.Range(15, 40));
                    SpawnPos = SpawnPos2;
                    break;
            }
            transform.position = SpawnPos;
        }
        if(AirBallon_UI.NumOfStage == 2)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            collision.gameObject.SetActive(false);
            AirBallon_UI.ScoreOfAirBallon++;
            int Sector = Random.Range(1, 3);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(10, -1.5f, Random.Range(15, 40));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(-10,-1.5f, Random.Range(15, 40));
                    SpawnPos = SpawnPos2;
                    break;
            }
            transform.position = SpawnPos;
        }
    }
}

