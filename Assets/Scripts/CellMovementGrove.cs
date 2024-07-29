using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CellMovementGrove : MonoBehaviour
{

    bool startGrove = false;
    Vector3 position1Grove;
    Vector3 position2Grove;

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
            int rIntGrove = rGrove.Next(0, 3);
            if (rIntGrove > 0) { return true; }
            else { return false; };
        }
        catch (System.Exception eGrove)
        {
            return false;
        }
    }
    public void Transition(RectTransform firstGrove, RectTransform secondGrove)
    {
        CoinFlipGrove(true);
        position1Grove = firstGrove.localPosition;
        position2Grove = secondGrove.localPosition;
        startGrove = true;

        if (firstGrove.localPosition != position2Grove)
        {
            CoinFlipGrove(true);
            firstGrove.localPosition = Vector3.Lerp(position1Grove, position2Grove, 0);
        }
        CoinFlipGrove(true);
        if (secondGrove.localPosition != position1Grove)
        {
            secondGrove.localPosition = Vector3.Lerp(position2Grove, position1Grove, 0);
        }
    }


}
