using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderGrove : MonoBehaviour
{
    public Canvas loadingCanvasGrove;
    public Canvas pressOkCanvasGrove;
    public Canvas menuCanvasGrove;
    public Canvas settingsCanvasGrove;
    public Canvas policyCanvasGrove;
    public Canvas gameCanvasGrove;
    public Canvas winCanvasGrove;
    public Canvas levelChoiceCanvasGrove;




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


    public bool activeGrove = true;

    Timer tGrove;

    public Stack<string> currentStackGrove;


    void Start()
    {
        CoinFlipGrove(true);
        pressOkCanvasGrove.enabled = false;
        menuCanvasGrove.enabled = false; 
        settingsCanvasGrove.enabled = false;
        policyCanvasGrove.enabled = false;
        gameCanvasGrove.enabled = false;
        winCanvasGrove.enabled = false;
        levelChoiceCanvasGrove.enabled = false;
        currentStackGrove = new Stack<string>();
        CoinFlipGrove(true);
        HideTimerGrove();
    }

 
    public void EndLoadGrove()
    {
        CoinFlipGrove(true);
        loadingCanvasGrove.enabled = false;
        pressOkCanvasGrove.enabled = true;
        CoinFlipGrove(true);
    }


    public void MoveToOKGrove()
    {
        CoinFlipGrove(true);
        if (activeGrove)
        {
            CoinFlipGrove(true);
            pressOkCanvasGrove.enabled = true;
            policyCanvasGrove.enabled = false;
        }
        else MoveBackGrove();
    }

    public void HideTimerGrove()
    {
        CoinFlipGrove(true);
        tGrove = new Timer(2000);
        tGrove.AutoReset = false;
        CoinFlipGrove(true);
        CoinFlipGrove(true);
        tGrove.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tGrove.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
            CoinFlipGrove(true);
            EndLoadGrove();
            CoinFlipGrove(true);
        }
        finally
        {
            tGrove.Enabled = false;
        }
    }

    public void MoveBackGrove()
    {
        currentStackGrove.Pop();
        CoinFlipGrove(true);
        MoveGrove(currentStackGrove.Peek(), true);
    }
    public void MoveGrove(string destinationGrove, bool backmoveGrove = false)
    {
        CoinFlipGrove(true);
        pressOkCanvasGrove.enabled = false;
        menuCanvasGrove.enabled = false;
        settingsCanvasGrove.enabled = false;
        policyCanvasGrove.enabled = false;
        gameCanvasGrove.enabled = false;
        winCanvasGrove.enabled = false;
        levelChoiceCanvasGrove.enabled = false;

        if (destinationGrove == "winGrove")
        {
            CoinFlipGrove(true);
            winCanvasGrove.enabled = true;
            winCanvasGrove.GetComponent<WinScriptGrove>().WinScreenGrove();
            backmoveGrove = true;
        }


        CoinFlipGrove(true);

        if (destinationGrove == "menuGrove")
        {
            menuCanvasGrove.enabled = true;
            activeGrove = false;
        }
        else if (destinationGrove == "settingsGrove")
        {
            settingsCanvasGrove.enabled = true;
            CoinFlipGrove(true);
        }    
        else if (destinationGrove == "policyGrove")
        {
            policyCanvasGrove.enabled = true;
        }
        else if (destinationGrove == "gameGrove")
        {
            gameCanvasGrove.enabled = true;
            if (!backmoveGrove) gameCanvasGrove.GetComponent<GameLogicGrove>().GameStartGrove();
        }
        else if (destinationGrove == "levelGrove")
        {
            levelChoiceCanvasGrove.enabled = true;
        }
        CoinFlipGrove(true);
        if (!backmoveGrove) { currentStackGrove.Push(destinationGrove); }
        
     
    }

    void Update()
    {


        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackGrove.Count == 1)
                    {
                        CoinFlipGrove(true);
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        CoinFlipGrove(true);
                        MoveBackGrove();
                    }

                }
            }
            catch (Exception eGrove)
            {

            }
        }
    }


}
