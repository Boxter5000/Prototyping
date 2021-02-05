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

    private void Awake()
    {
        messageText = transform.Find("Seperator").transform.Find("message").Find("messageText").GetComponent<Text>();

        transform.Find("Seperator").transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
            if(textWriterSingle != null && textWriterSingle.IsActive())
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
                            "Ouch, what happend?",
                            "Where are we?",
                            "I can not remember we got into a Dark Forrest.",
                            "We shoud try to get out of here. This is scary",
                            "You can move with W, A, S, D, or with your Arrow Keys",
                            "or Return one move with the R button"
                        };
                        if (counter < messagesArray_0.Length)
                        {
                            string message = messagesArray_0[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                        "Look at this Rock there.",
                        "It loocks like it is moveable.",
                        "try walking agenst it, maby you can push it."
                    };
                    if(counter < messagesArray_1.Length)
                    {
                        string message = messagesArray_1[counter];
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                            "That Log ther is blocking our Way.",
                            "it loocks to heavy to just push it,",
                            "but maby you can roll it away.",
                            "Walk from the top or from the bottem agenst it to get it out of the way."
                        };
                        if (counter < messagesArray_2.Length)
                        {
                            string message = messagesArray_2[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                            "There is a Slime gurding that candy",
                            "I dont know for what we need candy here in that Forest but you can collect it",
                            "because why not"
                        };
                        if (counter < messagesArray_3.Length)
                        {
                            string message = messagesArray_3[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                            "Look up There, more Monster!",
                            "Watch out for them, dont let them get you."
                        };
                        if (counter < messagesArray_4.Length)
                        {
                            string message = messagesArray_4[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                            "Well, ok",
                            "Nothing Happend.",
                            "Lets just move on."
                        };
                        if (counter < messagesArray_5.Length)
                        {
                            string message = messagesArray_5[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
                            "Lets just get out of that dam Forrest."
                        };
                        if (counter < messagesArray_6.Length)
                        {
                            string message = messagesArray_6[counter];
                            textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
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
        };
    }

    public void StartDialoge(int _dialogeIndex)
    {
        dialogeIndex = _dialogeIndex;
        transform.Find("Seperator").gameObject.SetActive(true);
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
