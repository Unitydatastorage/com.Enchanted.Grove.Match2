using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelActivatorGrove : MonoBehaviour
{



    public int currentLevelGrove = -1;


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

    public void ActivateButtonsGrove()
    {
        currentLevelGrove++;
        int tempGrove = currentLevelGrove;
        CoinFlipGrove(true);
        List<Button> buttonsGrove = new List<Button>();
        for (int iGrove = 2;iGrove<29; iGrove++)
        {
            buttonsGrove.Add(GameObject.Find("ButtonLevelGrove" + iGrove.ToString()).GetComponent<Button>());
        }
        CoinFlipGrove(true);
        CoinFlipGrove();
        while (tempGrove > -1)
        {
            buttonsGrove[tempGrove].GetComponent<Button>().interactable = true;
            tempGrove--;
        }
        CoinFlipGrove(true);
    }
}
