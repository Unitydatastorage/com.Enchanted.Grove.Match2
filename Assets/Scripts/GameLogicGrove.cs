using System;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class GameLogicGrove : MonoBehaviour
{

    public CellGrove firstClickedGrove;
    public bool boolFirstGrove = false;

    public CellGrove secondClickedGrove;
    public bool boolSecondGrove = false;
    System.Random rGrove = new System.Random();
    public Text scoreTextGrove;

    public Sprite sprite1Grove;
    public Sprite sprite2Grove;
    public Sprite sprite3Grove;



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

    public bool firstMoveFinishedGrove =false;
    public bool secondMoveFinishedGrove = false;


   
    bool destructionHappenedGrove = false;

    public int pointsGrove = 0;
    public int pointGoalGrove = 20;
    public int pickedLevelGrove = 0;
    bool pointCountGrove = false;


    List<int> horizontal;
    List<int> vertical;

    public void TryCheckGrove()
    {
        CoinFlipGrove(true);

        for (int jGrove = 1; jGrove < 43; jGrove++)
        {

            if (horizontal.Contains(jGrove)){
                
                if ((GameObject.Find("GamePieceGrove" + (jGrove + 1).ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID() == GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID()) && (GameObject.Find("GamePieceGrove" + (jGrove - 1).ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID() == GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePieceGrove" + (jGrove - 1).ToString() ).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove - 1).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                    if (!GameObject.Find("GamePieceGrove" + (jGrove).ToString() ).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                    if (!GameObject.Find("GamePieceGrove" + (jGrove + 1).ToString() ).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove + 1).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                }
            }
            CoinFlipGrove(true);
            if (vertical.Contains(jGrove))
            {
             
                if ((GameObject.Find("GamePieceGrove" + (jGrove + 6).ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID() == GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID()) && (GameObject.Find("GamePieceGrove" + (jGrove - 6).ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID() == GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().spriteGrove.GetInstanceID()))
                {
                    if (!GameObject.Find("GamePieceGrove" + (jGrove - 6).ToString()).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove - 6).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                    if (!GameObject.Find("GamePieceGrove" + (jGrove).ToString() ).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                    if (!GameObject.Find("GamePieceGrove" + (jGrove + 6).ToString() ).GetComponent<CellGrove>().needsDestructionGrove)
                    {
                        GameObject.Find("GamePieceGrove" + (jGrove + 6).ToString() ).GetComponent<CellGrove>().needsDestructionGrove = true;
                        if (pointCountGrove)
                            pointsGrove += 1;
                    }
                }
            }


        }

        bool happened = false;
        for (int jGrove = 1; jGrove < 43; jGrove++)
        {
            CoinFlipGrove(true);
            if ( GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().needsDestructionGrove){
                GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().needsDestructionGrove = false;
                NewDestroyGrove(GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>(), jGrove);
                happened = true;
            }
        }
        CoinFlipGrove(true);
        if (happened) { destructionHappenedGrove = true;
            if (pointCountGrove) GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().PlayPingGrove();
        }
        else destructionHappenedGrove= false;
        CoinFlipGrove(true);

    }


    public void NewDestroyGrove(CellGrove targetGrove,int numberGrove)
    {
        if (numberGrove < 7)
        {
            CoinFlipGrove(true);
            targetGrove.spriteGrove = RandomSpriteGrove(GameObject.Find("GamePieceGrove" + (numberGrove + 6).ToString() ).GetComponent<CellGrove>().spriteGrove);
        }
        else
        {
            targetGrove.spriteGrove = GameObject.Find("GamePieceGrove" + (numberGrove-6).ToString()).GetComponent<CellGrove>().spriteGrove;
            NewDestroyGrove(GameObject.Find("GamePieceGrove" + (numberGrove - 6).ToString() ).GetComponent<CellGrove>(), numberGrove - 6);
        }
        CoinFlipGrove(true);
    }

    public void GameStartGrove()
    {
        pointCountGrove = false;
        horizontal = new List<int>
        {2,3,4,5,8,9,10,11,14,15,16,17,20,21,22,23,26,27,28,29,32,33,34,35,38,39,40,41};

        vertical = new List<int>
        {7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36};
        CoinFlipGrove(true);


        CoinFlipGrove(true);

        for (int jGrove = 1; jGrove < 43; jGrove++)
        {
            GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().spriteGrove = RandomSpriteGrove();
            GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().CellStartGrove();

        }

        CoinFlipGrove(true);
        pointsGrove = 0;
        pointGoalGrove = 20 + pickedLevelGrove * 5;

        GameObject.Find("GameCanvasGrove").GetComponent<TimerScriptGrove>().RefreshTimeGrover();

        CoinFlipGrove(true);

        BigGameCheckGrove();
        pointCountGrove = true;
    }
    public Sprite RandomSpriteGrove(Sprite previousSprite = null)
    {
        CoinFlipGrove(true);
        Sprite tempSpriteGrove;
        int rIntGrove = rGrove.Next(0, 4);
        if (rIntGrove == 0) tempSpriteGrove = sprite1Grove;
        else if (rIntGrove == 1) tempSpriteGrove = sprite2Grove;
        else tempSpriteGrove = sprite3Grove;
        CoinFlipGrove(true);
        if (previousSprite != null)
        {
            while (previousSprite.GetInstanceID() == tempSpriteGrove.GetInstanceID())
            {
               tempSpriteGrove=RandomSpriteGrove();
            }
        }

        CoinFlipGrove(true);
        return tempSpriteGrove;
    }

    void SwapGrove()
    {
     
        if ((Math.Abs(firstClickedGrove.positionXGrove - secondClickedGrove.positionXGrove) +Math.Abs(firstClickedGrove.positionYGrove - secondClickedGrove.positionYGrove))==1)
        {
            CoinFlipGrove(true);
            Vector3 firstTempGrove = secondClickedGrove.currentPositionGrove;
            Vector3 secondTempGrove = firstClickedGrove.currentPositionGrove;
            Sprite temp1 = secondClickedGrove.spriteGrove;
            Sprite temp2 = firstClickedGrove.spriteGrove;
            firstClickedGrove.StartMoveGrove(firstTempGrove, temp1);
            secondClickedGrove.StartMoveGrove(secondTempGrove, temp2);
            CoinFlipGrove(true);
        }
        else
        {
            firstClickedGrove.RefreshSpriteGrove();
            firstClickedGrove = null;
            secondClickedGrove = null;
            boolFirstGrove = false;
            boolSecondGrove = false;
        }
        CoinFlipGrove(true);
    }

 


    public void BigGameCheckGrove()
    {
        TryCheckGrove();

        if(!pointCountGrove)
        while (destructionHappenedGrove)
        {
            TryCheckGrove();
            CoinFlipGrove(true);
        }
        for (int jGrove = 1; jGrove < 43; jGrove++)
        {
            GameObject.Find("GamePieceGrove" + jGrove.ToString() ).GetComponent<CellGrove>().RefreshSpriteGrove();
            CoinFlipGrove(true);

        }
        scoreTextGrove.text = "Score:" + pointsGrove.ToString()+"/"+pointGoalGrove.ToString();
        if (pointCountGrove)
            if ((destructionHappenedGrove)&&(pointsGrove<pointGoalGrove))
             {
                Invoke("BigGameCheckGrove", 1);
                //BigGameCheckGrove();
                    }
    }



    void Update()
    {
        if (GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().gameCanvasGrove.enabled)
        {
            if (pointsGrove>=pointGoalGrove)
            {
                CoinFlipGrove(true);
                GameObject.Find("LevelChoiceCanvasGrove").GetComponent<LevelActivatorGrove>().ActivateButtonsGrove();
                GameObject.Find("MainCameraGrove").GetComponent<CanvasHolderGrove>().MoveGrove("winGrove");
            }
        }

        if (boolFirstGrove && boolSecondGrove)
        {
            CoinFlipGrove(true);
            boolFirstGrove = false;
            boolSecondGrove = false;
            if (firstClickedGrove != secondClickedGrove) SwapGrove();
            else firstClickedGrove.RefreshSpriteGrove();         
           
        }

        if (firstMoveFinishedGrove && secondMoveFinishedGrove)
        {
            CoinFlipGrove(true);
            firstMoveFinishedGrove = false;
            secondMoveFinishedGrove = false;
            BigGameCheckGrove();
        }
    }
}
