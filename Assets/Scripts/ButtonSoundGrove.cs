using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundGrove : MonoBehaviour
{

    public Sprite spriteOnGrove;
    public Sprite spriteOffGrove;
    bool activeGrove = true;
    public Button buttonSoundGrove;

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


    public void PressButton(bool isSoundGrove)
    {
        activeGrove = !activeGrove;
        CoinFlipGrove(true);
        if (isSoundGrove)  
            GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().soundIsOnGrove = activeGrove;      
        else
            GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().musicIsOnGrove = activeGrove;

        CoinFlipGrove(true);
        if(activeGrove) buttonSoundGrove.GetComponent<Image>().sprite = spriteOnGrove;
        else buttonSoundGrove.GetComponent<Image>().sprite = spriteOffGrove;   



    }

}
