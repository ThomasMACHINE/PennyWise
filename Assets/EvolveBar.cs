using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// This can in theory be on any gameobject
// But since it deals entirely with UI
// I think it should be placed on the canvas object
// -Fredrik
public class EvolveBar : MonoBehaviour
{
    public Image bar;
    public Slider slider;
    public Gradient gradient;
    public Text text;
    private string evolveMessage = "Press E to evolve!";
    static GameObject[] objects;
    private string iconString = "icon";

    void Awake() {
        objects = GameObject.FindGameObjectsWithTag(iconString);
    }
    

    public void UpdateSlider(float fillPercentage) {
        slider.value = fillPercentage;
        bar.color = gradient.Evaluate(slider.value);
        
        if (fillPercentage >= 1)
        {
            EnableEvolveText();
        }
        else
        {
            DisableEvolveText();
        }
    }

    // having these as their own function is a bit overkill
    // but might be good if we expand the FX on evolving, so why not
    private void EnableEvolveText()
    {
        text.text = evolveMessage;
    }

    private void DisableEvolveText()
    {
        text.text = "";
    }

    public void UpdateScore(int score)
    {
        text.text = score.ToString();
    }

    public void UpdateEvolveScore(int coinScore) {
        foreach (var obj in objects){
            switch(obj.name){
                
                case "Zero":
                    if (coinScore == 0){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "One":
                    if (coinScore == 1){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Two":
                    if (coinScore == 2){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Three":
                    if (coinScore == 3){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Four":
                    if (coinScore == 4){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Five":
                    if (coinScore > 4){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                default:
                break;
            }
        }  
    }
}
