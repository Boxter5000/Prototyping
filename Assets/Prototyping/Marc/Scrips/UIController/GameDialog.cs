using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class GameDialog : MonoBehaviour
{

    [SerializeField] private float textSpeed;
    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private int counter;
    private int dialogeIndex;
    private AudioSource talkingAudioScource;

    private void Awake()
    {
        messageText = transform.Find("Seperator").transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioScource = transform.Find("Seperator").transform.Find("SoundPlayer").GetComponent<AudioSource>();

        transform.Find("Seperator").transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => 
        {
            PlayDialogue();
        };
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
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteOnDestroi();
        }
        else
        {
            switch (dialogeIndex)
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
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 1:
                    string[] messagesArray_1 = new string[]
                    {
                            "Look at the rock right in front of you.",
                            "It looks like it is moveable.",
                            "Try walking against it, maybe you can push it."
                    };
                    if (counter < messagesArray_1.Length)
                    {
                        string message = messagesArray_1[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 2:
                    string[] messagesArray_2 = new string[]
                    {
                            "That log there is blocking our way.",
                            "It looks too heavy to just push it away,",
                            "but maybe you can roll it over.",
                            "Walk from the top or the bottom against it to get it out of the way."
                    };
                    if (counter < messagesArray_2.Length)
                    {
                        string message = messagesArray_2[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 3:
                    string[] messagesArray_3 = new string[]
                    {
                            "Watch out!",
                            "There is a slime guarding something..",
                            "I think it is candy! I dont know why it is there but you can collect it,",
                            "because why not."
                    };
                    if (counter < messagesArray_3.Length)
                    {
                        string message = messagesArray_3[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 4:
                    string[] messagesArray_4 = new string[]
                    {
                            "Look up there, more monsters!",
                            "Watch out, dont let them get you."
                    };
                    if (counter < messagesArray_4.Length)
                    {
                        string message = messagesArray_4[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 5:
                    string[] messagesArray_5 = new string[]
                    {
                            "Well, ok.",
                            "Nothing happened.",
                            "Lets just move on."
                    };
                    if (counter < messagesArray_5.Length)
                    {
                        string message = messagesArray_5[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
                        StopDialoge();
                    }
                    break;
                case 6:
                    string[] messagesArray_6 = new string[]
                    {
                            "Why do you even bother picking them up,",
                            "Lets just get out of that damn forrest."
                    };
                    if (counter < messagesArray_6.Length)
                    {
                        string message = messagesArray_6[counter];
                        StartTalkingSound();
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        counter = 0;
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
