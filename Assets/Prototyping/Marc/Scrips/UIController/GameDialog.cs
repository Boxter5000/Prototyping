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
                        "Why are we still here?",
                        "Just to suffer?",
                        "every night, I can feel my leg...",
                        "And my arm...",
                        "even my fingers...",
                        "The body I've lost...",
                        "the comrades I've lost...",
                        "won't stop hurting...",
                        "It's like they're all still there.",
                        "You feel it, too, don't you? I'm gonna make them give back our past!"
                    };
                    if(counter < messagesArray_0.Length)
                    {
                        string message = messagesArray_0[counter];
                        textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
                        counter++;
                        //string message = messagesArray[Random.Range(0, messagesArray.Length)];
                    }
                    else
                    {
                        StopDialoge();
                    }
                    break;
                    case 1:
                        string[] messagesArray_1 = new string[]
                        {
                            "Das ist der Zweite text",
                            "Why are we still here?",
                            "Just to suffer?",
                            "every night, I can feel my leg...",
                            "And my arm...",
                            "even my fingers...",
                            "The body I've lost...",
                            "the comrades I've lost...",
                            "won't stop hurting...",
                            "It's like they're all still there.",
                            "You feel it, too, don't you? I'm gonna make them give back our past!"
                        };
                        if (counter < messagesArray_1.Length)
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
