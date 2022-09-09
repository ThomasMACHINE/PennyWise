using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EvolveBar : MonoBehaviour
{
    public Image bar;
    public Slider slider;
    public Gradient gradient;
    public UnityEvent evolveNotificationEventEnable;
    public UnityEvent evolveNotificationEventDisable;

    public void UpdateSlider(float fillPercentage) {
        slider.value = fillPercentage;
        bar.color = gradient.Evaluate(slider.value);
        
        if (fillPercentage >= 1)
        {
            evolveNotificationEventEnable.Invoke();
        }
        else
        {
            evolveNotificationEventDisable.Invoke();
        }
    }
}
