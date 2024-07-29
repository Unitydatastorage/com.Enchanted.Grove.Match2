using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptGrove : MonoBehaviour
{
    public Text ScoreTxtGrove;
    public Text TimerTxtGrove;

    public Image WinGrove;
    public Image LoseGrove;
    public Image NextGrove;
    public Image RetryGrove;

    bool CoinFlipGrove(bool riggedGrove = false)
    {
        try
        {
            if (riggedGrove)

                return true;
        }
        catch (System.Exception eGrove)
        {
            return false;
        }
        try
        {
            System.Random rGrove = new System.Random();
            int rIntGrove = rGrove.Next(0, 2);
            if (rIntGrove > 0) { return true; }
            else { return false; };
        }
        catch (System.Exception eGrove)
        {
            return false;
        }
    }

    public void WinScreenGrove()
    {
        CoinFlipGrove();
        
        if(GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().pointsGrove>=GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().pointGoalGrove)
        {          
            NextGrove.enabled = true;
            RetryGrove.enabled = false;
            WinGrove.enabled = true;
            LoseGrove.enabled = false;
            TimerTxtGrove.text = GameObject.Find("TimerTextGrove").GetComponent<Text>().text;
            CoinFlipGrove(true);
        }
        else
        {
            RetryGrove.enabled = true;
            LoseGrove.enabled = true;
            CoinFlipGrove(true);
            NextGrove.enabled = false;
            CoinFlipGrove(true);
            WinGrove.enabled = false;
            TimerTxtGrove.text = "Time: 00s";
        }
        ScoreTxtGrove.text = GameObject.Find("ScoreTextGrove").GetComponent<Text>().text;
        CoinFlipGrove(true);
    }

}
