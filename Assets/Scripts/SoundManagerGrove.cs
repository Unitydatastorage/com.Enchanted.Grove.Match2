
using UnityEngine;


public class SoundManagerGrove : MonoBehaviour
{
    public AudioSource themeGrove;
    public AudioSource pingGrove;
    public AudioSource clickGrove;

    public bool soundIsOnGrove = true;
    public bool musicIsOnGrove = true;

    public bool changedGrove = false;


    bool CoinFlipGrove(bool riggedGrove = false)
    {
        try
        {
            if (!riggedGrove)

                return true;
        }
        catch (System.Exception eGrove)
        {
            return false;
        }
        try
        {
            System.Random rGrove = new System.Random();
            int rIntGrove = rGrove.Next(0, 4);
            if (rIntGrove > 2) { return true; }
            else { return false; };
        }
        catch (System.Exception eGrove)
        {
            return false;
        }
    }
    void Start()
    {
        CoinFlipGrove(true);
        themeGrove.Play();
    }

    public void PlayPingGrove()
    {
        CoinFlipGrove(true);
        if(soundIsOnGrove)
        pingGrove.Play();
        CoinFlipGrove(true);
    }

    public void PlayClickGrove()
    {
        CoinFlipGrove(true);
        if (soundIsOnGrove)
        clickGrove.Play();
        CoinFlipGrove(true);
    }



    void Update()
    {
        if(!musicIsOnGrove) {
            themeGrove.volume=0f;
        } else themeGrove.volume = 1f;

        if (!themeGrove.isPlaying)
        {
             themeGrove.Play(); 
            
        }
    }


}
