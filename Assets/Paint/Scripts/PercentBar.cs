using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBar : MonoBehaviour
{
    public Slider slider;
    public Text percentText;

    public void SetMaxValue(float percent)
    {
        slider.maxValue = percent;
        slider.value = percent;
    }
    public void GetPercent(float percent)
    {
        slider.value = percent;
        percentText.text = Mathf.RoundToInt(slider.value) + " %";
    }
}
