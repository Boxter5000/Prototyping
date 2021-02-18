using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class CutsceneDialogue : MonoBehaviour
{

    [SerializeField] private float textSpeed;
    private Text HeroMessageText;
    private Text FriendMessageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private int counter = 0;
    private int dialogeIndex;
    private AudioSource talkingAudioScource;

    private void Awake()
    {
        HeroMessageText = transform.Find("Hero_Dialogue").transform.Find("message").Find("Background").Find("messageText").GetComponent<Text>();
        FriendMessageText = transform.Find("Friend_Dialogue").transform.Find("message").Find("Background").Find("messageText").GetComponent<Text>();

        talkingAudioScource = transform.Find("SoundPlayer").GetComponent<AudioSource>();

        PlayDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayDialogue();
        }
    }

    public void PlayDialogue()
    {
        Debug.Log("Go");
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteOnDestroi();
        }
        else
        {
            switch (counter)
            {
                case 0:
                    string[] messagesArray_0 = new string[]
                    {
                            "Ouch, what happened?",
                            "Where are we?",
                            "I can not remember how we got into a dark forrest.",
                            "We shoud try to get out of here. This is kinda scary...",
                            "You can move with W, A, S, D, or with the Arrow Keys",
                            "or return your move with the R button"
                    };
                    if (counter < messagesArray_0.Length)
                    {
                        string message = messagesArray_0[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(HeroMessageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter++;
                        StopDialoge();
                    }
                    break;
                case 1:
                    string[] messagesArray_1 = new string[]
                    {
                            "Ouch, what happened?",
                            "Where are we?",
                            "I can not remember how we got into a dark forrest.",
                            "We shoud try to get out of here. This is kinda scary...",
                            "You can move with W, A, S, D, or with the Arrow Keys",
                            "or return your move with the R button"
                    };
                    if (counter < messagesArray_1.Length)
                    {
                        string message = messagesArray_1[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(HeroMessageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter++;
                        StopDialoge();
                    }
                    break;
            }
        }
    }

    private void StartTalkingSound()
    {
        talkingAudioScource.Play();
    }
    private void StopTalkingSound()
    {
        talkingAudioScource.Stop();
    }

    public void StartDialoge(int _dialogeIndex)
    {
        dialogeIndex = _dialogeIndex;
        transform.Find("Seperator").gameObject.SetActive(true);
        PlayDialogue();
    }

    public void StopDialoge()
    {
        transform.Find("Seperator").gameObject.SetActive(false);
    }

    private void Start()
    {
        //TextWriter.AddWriter_Static(messageText, "This is the Text that is spoken by the Friend", textSpeed, true);
    }
}
