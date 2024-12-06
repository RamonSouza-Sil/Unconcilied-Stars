using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float typingSpeed = 0.05f; 
    private string[] sentences;
    private int index;
    private bool isTyping;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        index = 0;

        
        if (playerController != null)
        {
            playerController.canMove = false;
        }

        StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        isTyping = true;
        speechText.text = ""; 
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter; 
            yield return new WaitForSeconds(typingSpeed); 
        }
        isTyping = false; 
    }

    public void NextSentence()
    {
        if (!isTyping && speechText.text == sentences[index]) 
        {
            if (index < sentences.Length - 1)
            {
                index++; 
                StartCoroutine(TypeSentence()); 
            }
            else
            {
                EndDialogue(); 
            }
        }
    }

    public void SkipToNextSentence()
    {
        StopAllCoroutines(); 
        if (index < sentences.Length - 1)
        {
            index++; 
            speechText.text = ""; 
            StartCoroutine(TypeSentence()); 
        }
        else
        {
            EndDialogue(); 
        }
    }

    private void EndDialogue()
    {
        speechText.text = ""; 
        dialogueObj.SetActive(false); 

        
        if (playerController != null)
        {
            playerController.canMove = true;
        }
    }
}






