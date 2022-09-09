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

    private int coinToEvolve = 5;
    
    public void UpdateSlider(int amount) {
        slider.value = (float)amount / coinToEvolve;
        bar.color = gradient.Evaluate(slider.value);
        
        if ((float)amount / coinToEvolve >= 1)
        {
            evolveNotificationEventEnable.Invoke();
        }
        else
        {
            evolveNotificationEventDisable.Invoke();
        }
    }
}
