using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{

    GameObject[] objects;

    void Start() {
        objects = GameObject.FindGameObjectsWithTag("icon");
    }


//Doesnt work
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
                    if (size == "Dragon_MEDIUM" || size == "Dragon_LARGE"){
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

                default:
                    Debug.Log("Logical Mistake Made");
                break;
            }
        }  
    }
}