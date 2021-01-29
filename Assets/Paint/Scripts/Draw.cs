using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Draw : MonoBehaviour
{
    public float maxPercent = 100;
    public float currentPercent;
    public GameObject nextButton;

    public PaintSectionManager pC;
    public GameObject Brush;
    public float BrushSize;
    public Camera paintCamera;

    public PercentBar percentBar;

    bool btnActive = false;
    bool c1, c2, c3, c4, c5;

    private void Start()
    {
        currentPercent = maxPercent;
        percentBar.SetMaxValue(currentPercent);
    }

    void SetPercent(float value)
    {
        currentPercent -= value;
        percentBar.GetPercent(currentPercent);
    }

    public void NextStep()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && pC.gameIsContinue == false && pC.paintIsReady == true && !btnActive)
        {
            var Ray = paintCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.Euler(0,0,90f), transform);
                go.transform.localScale = Vector3.one * BrushSize;

                if (hit.collider.CompareTag("check1") && !c1)
                {
                    SetPercent(20);
                    c1 = true;
                }
                else if (hit.collider.CompareTag("check2") && !c2)
                {
                    SetPercent(20);
                    c2 = true;
                }
                else if (hit.collider.CompareTag("check3") && !c3)
                {
                    SetPercent(20);
                    c3 = true;
                }
                else if (hit.collider.CompareTag("check4") && !c4)
                {
                    SetPercent(20);
                    c4 = true;
                }
                else if (hit.collider.CompareTag("check5") && !c5)
                {
                    SetPercent(20);
                    c5 = true;
                }

            }
         
        }

        if(c1 && c2 && c3 && c4 && c5)
        {
            btnActive = true;
            nextButton.SetActive(true);
            
        }
    }
}
