using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMeneger : MonoBehaviour
{
    //знаю, говнокод, но что поделать. ќставл€ю так, лень!
    private AirBallonScript AirBallon;
    public GameObject AirBallonMotherObj;
    public GameObject TargetMotherObj;
    public Camera Cam;
    public int ScoreOfTarget = 0;
    public Text ScoreOfTarget_UI;
    public int ScoreOfAirBallon = 0;
    public Text ScoreOfAirBallon_UI;
    public GameObject[] UIInfo;

    public bool FirstStageFinished = false;
    public bool SecondStageFinished = false;


    void Start()
    {
        AirBallon = AirBallonMotherObj.GetComponent<AirBallonScript>();
    }

    void FixedUpdate()
    {
        if (!FirstStageFinished)
        {
            ScoreOfTarget_UI.text = ScoreOfTarget.ToString();
            if (Cam.fieldOfView < 50)
            {
                UIInfo[0].gameObject.SetActive(false);
            }
            else if (Cam.fieldOfView >= 50)
            {
                UIInfo[0].gameObject.SetActive(true);
            }


            if (ScoreOfTarget == 5)
            {
                UIInfo[0].gameObject.SetActive(false);
                FirstStageFinished = true;
                AirBallon.gameObject.SetActive(true);
                TargetMotherObj.transform.position = new(100, 20, 100);
            }
        }else
        {
            UIInfo[0].gameObject.SetActive(false);
        }
        if (!SecondStageFinished && FirstStageFinished)
        {
            ScoreOfAirBallon_UI.text = ScoreOfAirBallon.ToString();
            if (Cam.fieldOfView < 50)
            {
                UIInfo[1].gameObject.SetActive(false);
            }
            else if (Cam.fieldOfView >= 50)
            {
                UIInfo[1].gameObject.SetActive(true);
            }
            if (ScoreOfAirBallon == 3)
            {
                UIInfo[1].gameObject.SetActive(false);
                SecondStageFinished = true;
            }

        }
        else
        {
            UIInfo[1].gameObject.SetActive(false);
        }

    }
}
