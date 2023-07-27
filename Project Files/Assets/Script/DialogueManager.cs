using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    [Range(0.001f,1f)]
    public float textSpeed = 0.02f;
    
    public void DisplaySentece(string sentence)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(sentence));
    }

    public void DisplaySenteceInFile(TextAsset file)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(file.text));
    }

    IEnumerator TypeText(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    public void ChangeTypeSpeed(float speed)
    {
        textSpeed = speed;
    }
}
