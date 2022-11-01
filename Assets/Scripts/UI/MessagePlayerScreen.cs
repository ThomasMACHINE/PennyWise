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
    private List<MessageBody> pendingMessages = new List<MessageBody>();
    [SerializeField] Image MessengerIcon;

    [SerializeField]
    private Sprite
        none,
        dragon,
        golem;

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
        NotifyPlayer(newTitle, newBody, Messenger.none);
    }

    public void NotifyPlayer(string newTitle, string newBody, Messenger messenger)
    {
        MessageBody mb = new MessageBody(newTitle, newBody, messenger);

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

        setMessengerIcon(mb.messenger);
    }

    private void setMessengerIcon(Messenger messenger)
    {
        MessengerIcon.color = new Vector4(MessengerIcon.color.r, MessengerIcon.color.g, MessengerIcon.color.b, 1);
        switch (messenger)
        {
            case Messenger.Dragon:
                MessengerIcon.sprite = dragon;
                break;

            case Messenger.GoldGolem:
                MessengerIcon.sprite = golem;
                break;

            default:
                MessengerIcon.color = new Vector4(MessengerIcon.color.r, MessengerIcon.color.g, MessengerIcon.color.b, 0); 
                break;
        }
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
                Debug.Log(pendingMessages.Count);

                sendMessage(pendingMessages[0]);
                pendingMessages.RemoveAt(0);
                Debug.Log(pendingMessages.Count);

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

        if (isDisplaying)
        {
            if (newMessageBody.title.Equals(Title.text) && newMessageBody.body.Equals(Body.text))
            {
                foundDuplicate = true;
            }
        }
        
        foreach(MessageBody mb in pendingMessages)
        {
            if (newMessageBody.title.Equals(mb.title) && newMessageBody.body.Equals(mb.body))
            {
                foundDuplicate = true;
            }
        }
        return foundDuplicate;
    }

    public enum Messenger 
    {
        none, 
        Dragon, 
        GoldGolem
    };

    public struct MessageBody 
    {
        public
        string title, body;
        public Messenger messenger;

        public MessageBody(string title, string body, Messenger messenger)
        {
            this.title = title;
            this.body = body;
            this.messenger = messenger;
        }
    }
}

