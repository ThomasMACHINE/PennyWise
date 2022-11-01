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

    private bool isDisplaying = false;
    [SerializeField] private List<MessageBody> pendingMessages = new List<MessageBody>();

    private void Awake()
    {
        if (!Panel)
            Debug.LogError("Message Player system is missing Panel game-object");

        if (!Body) 
            Debug.LogError("Message Player system is missing Body text-box");

        
        if (!Title)
            Debug.LogError("Message Player system is missing Title text-box");
    }
    public void NotifyPlayer(string newTitle, string newBody) 
    {
        MessageBody mb = new MessageBody(newTitle, newBody);

        if (isDuplicate(mb))
            return;

        if (isDisplaying)
        {
            pendingMessages.Add(mb);
        }

        if (!isDisplaying)
        {
            sendMessage(mb);
        }
    }

    private void sendMessage(MessageBody mb) {
        Panel.SetActive(true);
        Panel.transform.position = new Vector3(960, 1200, 0);
        Title.text = mb.title;
        Body.text = mb.body;
        isDisplaying = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pendingMessages.Clear();
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (pendingMessages.Count != 0)
            {
                sendMessage(pendingMessages[0]);
                pendingMessages.RemoveAt(0);
            }
            else {
                Panel.SetActive(false);
                isDisplaying = false;
            }
        }
        Panel.transform.position = Vector3.MoveTowards(Panel.transform.position, new Vector3(960, 845, 0), 20);
    }

    private bool isDuplicate(MessageBody newMessageBody)
    {
        if (pendingMessages.Count == 0)
            return false;

        bool foundDuplicate = false;
        foreach(MessageBody mb in pendingMessages)
        {
            if (newMessageBody.title.Equals(mb.title) && newMessageBody.body.Equals(mb.body))
            {
                foundDuplicate = true;
            }
        }
        return foundDuplicate;
    }
    public struct MessageBody 
    {
        public
        string title, body;
        public MessageBody(string title, string body)
        {
            this.title = title;
            this.body = body;
        }
    }
}

