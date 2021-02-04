using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharakter, invisibleCharacter);
    }

    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharakter, invisibleCharacter);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
            if(textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool desttroyInstance = textWriterSingleList[i].Update();
            if (desttroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle
    {

        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharakter;
        private float timer;
        private bool invisibleCharacter;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharakter = timePerCharakter;
            this.invisibleCharacter = invisibleCharacter;
            characterIndex = 0;
        }


        public bool Update()
        {

                timer -= Time.deltaTime;
                while (timer <= 0f)
                {
                    timer += timePerCharakter;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);
                    if (invisibleCharacter)
                    {
                        text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text;

                    if (characterIndex >= textToWrite.Length)
                    {
                        return true;
                    }
                }

                return false;
        }

        public Text GetUIText()
        {
            return uiText;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteOnDestroi()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(uiText);
        }


    }
}
