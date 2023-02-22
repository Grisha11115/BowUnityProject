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

    public int NumOfStage = 1;
    public GameObject Winner;
    public GameObject Loser;

    public GameObject BossBobr;

    public Slider LogsSlider;
    public GameObject Logs;
    public GameObject SecondLog;
    void Start()
    {
        LogsSlider.maxValue = 200f;
        LogsSlider.value = 200f;
        AirBallon = AirBallonMotherObj.GetComponent<AirBallonScript>();
    }

    void Update()
    {
        switch (NumOfStage)
        {
            case 1:
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
                    NumOfStage = 2;
                    UIInfo[0].gameObject.SetActive(false);
                    AirBallon.gameObject.SetActive(true);
                    TargetMotherObj.transform.position = new(100, 20, 100);
                }
                if (NumOfStage == 1)
                {
                    UIInfo[0].gameObject.SetActive(true);
                }
                break;
            case 2:
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
                    NumOfStage = 3;
                }
                break;
            case 3:
                Logs.gameObject.SetActive(true);
                LogsSlider.gameObject.SetActive(false);
                if (Cam.fieldOfView < 50)
                {
                    LogsSlider.gameObject.SetActive(false);
                    UIInfo[2].gameObject.SetActive(false);
                }
                else if (Cam.fieldOfView >= 50)
                {
                    LogsSlider.gameObject.SetActive(true);
                    UIInfo[2].gameObject.SetActive(true);
                }
                if(SecondLog.GetComponent<SecondAngryLogScript>().LogHP <= 0)
                {
                    UIInfo[2].gameObject.SetActive(false);
                }
                if (LogsSlider.value == 0)
                {
                    YouLoser();
                }

                break;
            case 4:
                LogsSlider.gameObject.SetActive(false);
                BossBobr.gameObject.SetActive(true);
                if (Cam.fieldOfView < 50)
                {
                    UIInfo[3].gameObject.SetActive(false);
                }
                else if (Cam.fieldOfView >= 50)
                {
                    UIInfo[3].gameObject.SetActive(true);
                }
                break;
        }
    }
    private void FixedUpdate()
    {
        if(NumOfStage == 3)
            LogsSlider.value -= 0.1f;
    }
    public void YouWinner()
    {
        Winner.gameObject.SetActive(true);

    }
    public void YouLoser()
    {
        Loser.gameObject.SetActive(true);
    }
}
