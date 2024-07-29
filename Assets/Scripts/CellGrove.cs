using System.Collections;
using UnityEngine;


public class CellGrove : MonoBehaviour
{

    public int positionXGrove;
    public int positionYGrove;
    public Sprite spriteGrove;
    public Vector3 currentPositionGrove;
    public bool needsDestructionGrove = false;



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

    public void OnClickGrove()
    {
        GameObject.Find("MainCameraGrove").GetComponent<SoundManagerGrove>().PlayClickGrove();
        if (!GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().boolFirstGrove)
        {
            GetComponent<UnityEngine.UI.Image>().color = Color.green;
            GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().firstClickedGrove = this;
            GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().boolFirstGrove = true;
            CoinFlipGrove(true);
        }
        else if (!GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().boolSecondGrove)
        {
            CoinFlipGrove(true);
            GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().secondClickedGrove = this;
            GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().boolSecondGrove = true;
        }
    }

    public void RefreshSpriteGrove()
    {
        CoinFlipGrove(true);
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        GetComponent<UnityEngine.UI.Image>().sprite = spriteGrove;
    }




    public void StartMoveGrove(Vector3 destinationGrove, Sprite newSpriteGrove)
    {
        CoinFlipGrove(true);
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        StartCoroutine(moveObjectGrove(destinationGrove, newSpriteGrove));
    }

    public IEnumerator moveObjectGrove(Vector3 destinationGrove, Sprite newSpriteGrove)
    {
        CoinFlipGrove(true);
        float totalMovementTimeGrove = 1f; 
        float currentMovementTimeGrove = 0f;
        while (Vector3.Distance(transform.localPosition, destinationGrove) > 0)
        {
            currentMovementTimeGrove += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(currentPositionGrove, destinationGrove, currentMovementTimeGrove / totalMovementTimeGrove);
            yield return null;
        }
        transform.localPosition = currentPositionGrove;
        spriteGrove = newSpriteGrove;
        RefreshSpriteGrove();
        CoinFlipGrove(true);
        if (GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().firstMoveFinishedGrove == false)
        {
            GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().firstMoveFinishedGrove = true;
        }
        else GameObject.Find("GameCanvasGrove").GetComponent<GameLogicGrove>().secondMoveFinishedGrove = true;

    }


    public void CellStartGrove()
    {
        CoinFlipGrove(true);
        currentPositionGrove = transform.localPosition;
        RefreshSpriteGrove();
    }

  
   
}
