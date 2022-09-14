using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class DisplayMessageOnEvent : MonoBehaviour
{
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
    }

    public void DisplayText(string message)
    {
        StartCoroutine(DisplayThenWait(_text, message, 5));
    }

    public IEnumerator DisplayThenWait(Text textComponent, string message, float timeToDisplay)
    {
        textComponent.text = message;
        yield return new WaitForSeconds(timeToDisplay);
        textComponent.text = "";
    }
}
