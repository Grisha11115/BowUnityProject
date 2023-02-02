using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBallonScript : MonoBehaviour
{
    public GameObject AirBallon_UI;
    public Text ScoreOfAirBallon_UI;
    public Text YouLostAirBallon_UI;

    private int ScoreOfAirBallon = 0;

    private int Timer;
    private bool TimerIsOn;


    // Start is called before the first frame update

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (TimerIsOn)
            Timer++;

    }
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
        if (transform.position.y >= 20)
        {
            Timer = 0;
            TimerIsOn = true;
            YouLostAirBallon_UI.gameObject.SetActive(true);
        }
        if (Timer >= 180)
        {
            transform.position = new Vector3(25, -1.5f, Random.Range(15, 50));
            YouLostAirBallon_UI.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            collision.gameObject.SetActive(false);
            ScoreOfAirBallon++;
            ScoreOfAirBallon_UI.text = ScoreOfAirBallon.ToString();
            Vector3 SpawnPos = new(0, 1.5f, 50);
            int Sector = Random.Range(1, 3);
            switch (Sector)
            {
                case 1:
                    Vector3 SpawnPos1 = new(25, -1.5f, Random.Range(15, 50));
                    SpawnPos = SpawnPos1;
                    break;
                case 2:
                    Vector3 SpawnPos2 = new(-25,-1.5f, Random.Range(15, 50));
                    SpawnPos = SpawnPos2;
                    break;
            }
            transform.position = SpawnPos;
        }
    }
}

