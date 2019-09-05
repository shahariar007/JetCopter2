using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimation : MonoBehaviour
{
    public float letterPause = 0.2f;
    //public AudioClip typeSound1;
    //public AudioClip typeSound2;

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            //if (typeSound1 && typeSound2)
            // SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            // yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}