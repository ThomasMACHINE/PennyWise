using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolveBar : MonoBehaviour
{
    public Image bar;
    public Slider slider;
    public Gradient gradient;

    public void UpdateSlider(float fillPercentage) {
        slider.value = fillPercentage;
        bar.color = gradient.Evaluate(slider.value);
        
        if (fillPercentage >= 1) Debug.Log("Press E to evolve!");
    }
}
