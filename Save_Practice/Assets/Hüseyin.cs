using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hüseyin : MonoBehaviour { 


    public TextMeshProUGUI personalBestGO;
    public TextMeshProUGUI waitingTextGO;
    bool timerActivated = false;
    float timer;
    int highscore;

    
    void Start()
    {
        waitingTextGO.text = "Are you ready to wait?..";
        if (PlayerPrefs.HasKey("PersonalBest"))
        {
            highscore = PlayerPrefs.GetInt("PersonalBest");

        }
        else
        {
            PlayerPrefs.SetInt("PersonalBest", 0);
            highscore = PlayerPrefs.GetInt("PersonalBest");

        }


        personalBestGO.text = " Personal Score:" + PlayerPrefs.GetInt("PersonalBest");


    }


    void Update()
    {
      if ( timerActivated)
        {
            timer += Time.deltaTime;
            waitingTextGO.text = timer.ToString();

        }
    }
    public void OnClickResetButton()
    {
        timer = 0;
        timerActivated = false;
        waitingTextGO.text = timer.ToString();
        PlayerPrefs.DeleteAll();
        personalBestGO.text = " Personal Score:" + PlayerPrefs.GetInt("PersonalBest");

    }

    public void OnClickWaitButton()
    {
        timer = 0;
        timerActivated = true;
    }
    public void OnClickEnoughButton()
    {
        timerActivated = false;
        if (highscore < (int) timer)
        {
            highscore = (int)timer;
            PlayerPrefs.SetInt("PersonalBest", highscore);
            personalBestGO.text = " Personal Score:" + PlayerPrefs.GetInt("PersonalBest");
        }

    }     
}
