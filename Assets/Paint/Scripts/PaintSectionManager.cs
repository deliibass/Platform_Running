using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSectionManager : MonoBehaviour
{
    public bool gameIsContinue = true;
    public bool paintIsReady = false;
    public GameObject camera1;
    public GameObject camera2;

    public GameObject itemCountText, percentBar;

    public GameObject turnBackText;
    public GameObject paintText;
    private int paintCount = 4;
    private static int paintCheck;
    
    private void Update() {
        paintCheck = GameManager.currentItem;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(paintCheck == paintCount){
            gameIsContinue = false;
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(PaintCo());
                camera1.SetActive(false);
                camera2.SetActive(true);

                itemCountText.SetActive(false);
                percentBar.SetActive(true);
            }
        }else{
            StartCoroutine(TurnBackCo());
        }
        
    }

    IEnumerator TurnBackCo(){
        turnBackText.SetActive(true);
        yield return new WaitForSeconds(2);
        turnBackText.SetActive(false);
    }

    IEnumerator PaintCo()
    {
        yield return new WaitForSeconds(2);
        paintText.SetActive(true);
        yield return new WaitForSeconds(1f);
        paintIsReady = true;
        paintText.SetActive(false);

    }
}
