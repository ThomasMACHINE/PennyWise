using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventInvokeOnRightClick : MonoBehaviour
{
    public UnityEvent demoEvent;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            demoEvent.Invoke();
    }
}
