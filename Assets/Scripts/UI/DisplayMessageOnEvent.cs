using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class DisplayMessageOnEvent : MonoBehaviour
{
    private Text _text;
    private float timeStartDisplay;
    private float coolDownTime = 0.5f;
    private bool messageActive = false;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        // probably unecesarry, but i hate uninitialized values
        timeStartDisplay = Time.time;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && messageActive)
        {
            if (Time.time - timeStartDisplay > coolDownTime)
            {
                _text.text = "";
            }
        }
    }

    public void DisplayTextUntilFire(string message)
    {
        _text.text = message;
        timeStartDisplay = Time.time;
        messageActive = true;
    }

    public void DisplayText(string message, float timeToDisplay)
    {
        StartCoroutine(DisplayThenWait(_text, message, timeToDisplay));
    }

    public IEnumerator DisplayThenWait(Text textComponent, string message, float timeToDisplay)
    {
        textComponent.text = message;
        yield return new WaitForSeconds(timeToDisplay);
        textComponent.text = "";
    }
}
