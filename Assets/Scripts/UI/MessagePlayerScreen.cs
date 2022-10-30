using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessagePlayerScreen : MonoBehaviour
{
    public GameObject Panel;
    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI Body;

    private void Awake()
    {
        Debug.Log(Panel.transform.position);
        if (!Panel)
            Debug.LogError("Message Player system is missing Panel game-object");

        if (!Body) 
            Debug.LogError("Message Player system is missing Body text-box");

        
        if (!Title)
            Debug.LogError("Message Player system is missing Title text-box");
    }
    public void NotifyPlayer(string newTitle, string newBody) 
    {
        Panel.transform.position = new Vector3(960, 1200, 0);
        Panel.SetActive(true);
        Title.text = newTitle;
        Body.text = newBody;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            Panel.SetActive(false);

        Panel.transform.position += new Vector3(0, 5, 0);

        Panel.transform.position = Vector3.MoveTowards(Panel.transform.position, new Vector3(960, 845, 0), 20);
    }
}
