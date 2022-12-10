using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    static GameObject[] objects;
    private string iconString = "icon";
    private string roarString = "Roar";
    private string smallDragonString = "Dragon_SMALL";
    private string mediumDragonString = "Dragon_MEDIUM";
    private string largeDragonString = "Dragon_LARGE";


    void Awake() {
        objects = GameObject.FindGameObjectsWithTag(iconString);
    }

    //Removes the roar icon if roar has been used recently
    public void UpdateRoarUsed(bool showCooldown){
        if (showCooldown){
            foreach (var obj in objects){
                if (obj.name == roarString){
                    obj.SetActive(false);
                    
                }
            }
        } else {
            foreach (var obj in objects){
                if (obj.name == roarString){
                    obj.SetActive(true);
                    
                }
            }
        }

    }

    public void UpdateIcons(string size) {
        //var objects = GameObject.FindGameObjectsWithTag("icon");
        foreach (var obj in objects){
            switch(obj.name){
                
                case "Glide":
                    if (size == smallDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Hide":
                    if (size == smallDragonString || size == mediumDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "DoubleJump":
                    if (size == mediumDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Carry":
                    if (size == mediumDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Roar":
                    if (size == largeDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Small":
                    if (size == smallDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Medium":
                    if (size == mediumDragonString){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;
                
                case "Large":
                    if (size == largeDragonString){
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
