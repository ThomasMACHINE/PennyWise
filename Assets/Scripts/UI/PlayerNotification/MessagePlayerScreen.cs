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

    [SerializeField] NotificationMessenger messengerStorage;

    [SerializeField] Vector3 screenInterpolationStartPoint;
    [SerializeField] Vector3 screenInterpolationEndPoint;
    [SerializeField] float interpolationSpeed;

    //Remove current popup
    bool showPopup = true;
    Coroutine timer;
    

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
        NotifyPlayer(newTitle, newBody, NotificationMessenger.Messenger.none);
    }

    public void NotifyPlayer(string newTitle, string newBody, NotificationMessenger.Messenger messenger)
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
        Panel.transform.position = screenInterpolationStartPoint;
        Title.text = mb.title;
        Body.text = mb.body;
        isDisplaying = true;
        timer = StartCoroutine(popupTimer());
        setMessengerIcon(mb.messenger);
        
    }

    private void setMessengerIcon(NotificationMessenger.Messenger messenger)
    {
        MessengerIcon.sprite = messengerStorage.GetMessenger(messenger);
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
                StopCoroutine(timer);
                Panel.SetActive(false);
                isDisplaying = false;
            }
        } 
        if (!showPopup){
            showPopup = true; //Resetting the timer for the popup
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
        Panel.transform.position = Vector3.MoveTowards(Panel.transform.position, screenInterpolationEndPoint, interpolationSpeed);
    }

    IEnumerator popupTimer()
    {

        yield return new WaitForSeconds(5);
  
        showPopup = false;
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


    public struct MessageBody 
    {
        public
        string title, body;
        public NotificationMessenger.Messenger messenger;

        public MessageBody(string title, string body, NotificationMessenger.Messenger messenger)
        {
            this.title = title;
            this.body = body;
            this.messenger = messenger;
        }
    }
}

