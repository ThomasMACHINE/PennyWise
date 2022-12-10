using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    static GameObject[] objects;

    void Awake() {
        objects = GameObject.FindGameObjectsWithTag("icon");
    }

    //Removes the roar icon if roar has been used recently
    public void UpdateRoarUsed(bool showCooldown){
        if (showCooldown){
            foreach (var obj in objects){
                if (obj.name == "Roar"){
                    obj.SetActive(false);
                    
                }
            }
        } else {
            foreach (var obj in objects){
                if (obj.name == "Roar"){
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
                    if (size == "Dragon_SMALL"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Hide":
                    if (size == "Dragon_SMALL" || size == "Dragon_MEDIUM"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "DoubleJump":
                    if (size == "Dragon_MEDIUM"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Carry":
                    if (size == "Dragon_MEDIUM"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Roar":
                    if (size == "Dragon_LARGE"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Small":
                    if (size == "Dragon_SMALL"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;

                case "Medium":
                    if (size == "Dragon_MEDIUM"){
                        obj.SetActive(true);
                    } else {
                        obj.SetActive(false);
                    }
                    break;
                
                case "Large":
                    if (size == "Dragon_LARGE"){
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
