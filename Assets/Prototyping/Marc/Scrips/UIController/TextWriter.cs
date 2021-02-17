using System;
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

    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter, bool removeWriterBeforeAdd, Action OnComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharakter, invisibleCharacter, OnComplete);
    }

    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter, Action OnComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharakter, invisibleCharacter, OnComplete);
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
        private Action OnComplete;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharakter, bool invisibleCharacter, Action OnComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharakter = timePerCharakter;
            this.invisibleCharacter = invisibleCharacter;
            this.OnComplete = OnComplete;
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
                    if (OnComplete != null) OnComplete();
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
            if (OnComplete != null) OnComplete();
            TextWriter.RemoveWriter_Static(uiText);
        }
    }
}
