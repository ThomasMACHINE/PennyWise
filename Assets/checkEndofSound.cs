using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkEndofSound : MonoBehaviour
{
    AudioSource mySound;
    public bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        mySound = GetComponent<AudioSource>();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mySound.isPlaying){
            isPlaying = true;
        }
    }
}
