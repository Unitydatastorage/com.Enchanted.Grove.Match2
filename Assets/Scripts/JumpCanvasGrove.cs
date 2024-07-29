using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasGrove : MonoBehaviour
{

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

    public void JumpGrove(string destinationGrove)
    {
        CoinFlipGrove(true);
        GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().PlayClickGrove();
        GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().MoveGrove(destinationGrove,false);
    }


    public void JumpGroveLevel(int levelGrove)
    {
        CoinFlipGrove(true);
        GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().pickedLevelGrove = levelGrove;
        JumpGrove("gameGrove");
        CoinFlipGrove(true);
    }


    public void JumpBackGrove()
    {
        CoinFlipGrove(true);
        GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().PlayClickGrove();
        GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().MoveBackGrove();
    }

    public void JumpOKGrove()
    {
        CoinFlipGrove(true);
        GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().PlayClickGrove();
        GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().MoveToOKGrove();
        CoinFlipGrove(true);
    }

    public void CloseGrove()
    {
        CoinFlipGrove(true);
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        CoinFlipGrove(true);
    }
}
