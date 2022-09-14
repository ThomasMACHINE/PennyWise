using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventInvokeOnA : MonoBehaviour
{
    public UnityEvent demoEvent;

    // taken from http://answers.unity.com/answers/1542779/view.html
    void OnGUI()
    {
        Event e = Event.current;

    //Check the type of the current event, making sure to take in only the KeyDown of the keystroke.
    //char.IsLetter to filter out all other KeyCodes besides alphabetical.
    if (e.type == EventType.KeyDown &&
        e.keyCode.ToString().Length == 1 &&
        char.IsLetter(e.keyCode.ToString()[0]))
        {
            //This is your desired action
            demoEvent.Invoke();
        }

    }
}
