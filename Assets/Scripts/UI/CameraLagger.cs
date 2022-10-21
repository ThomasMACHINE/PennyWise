using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLagger : MonoBehaviour
{
    [SerializeField] float duration;
    private float t = 0;
    [SerializeField] CameraController CC;

    private void Start()
    {
        CC.updateSpeed = 5;
    }
    void Update()
    {
        t += Time.deltaTime;

        if (t >= duration) {
            CC.updateSpeed = 50;
        }
    }
}
