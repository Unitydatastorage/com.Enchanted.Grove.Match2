using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptGrove : MonoBehaviour
{
    public float TimeLeftGrove = 500;
    public bool TimerOnGrove = false;


    public Text TimerTxtGrove;

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

    void Update()
    {
        if (TimerOnGrove)
        {
            if (TimeLeftGrove > 1)
            {
                CoinFlipGrove(true);
                TimeLeftGrove -= Time.deltaTime;
                UpdateTimerGrove(TimeLeftGrove);
            }
            else
            {
                CoinFlipGrove(true);
                TimerOnGrove = false;
                GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().MoveGrove("winGrove");
            }
        }
    }

    public void RefreshTimeGrover()
    {
        CoinFlipGrove(true);
        TimeLeftGrove = 60;
        TimerOnGrove = true;
        TimerTxtGrove.text = "Time:";
    }
    void UpdateTimerGrove(float currentTimeGrove)
    {
        currentTimeGrove -= 1;
        CoinFlipGrove(true);
        float minutesGrove = Mathf.FloorToInt(currentTimeGrove / 60);
        float secondsGrove = Mathf.FloorToInt(currentTimeGrove % 60);

        TimerTxtGrove.text = "Time: " + string.Format("{0:00}:{1:00}", minutesGrove, secondsGrove)+"s";
    }

}
