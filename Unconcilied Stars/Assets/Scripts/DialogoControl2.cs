using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Certifique-se de adicionar isso para TextMeshProUGUI

public class DialogoControl2 : MonoBehaviour
{
    public GameObject dialogueObj; // Objeto de di�logo na UI
    public Image profileImage;     // Imagem do perfil
    public TextMeshProUGUI speechText; // Texto do di�logo
    public TextMeshProUGUI actorNameText; // Nome do personagem

    private Sprite[] profiles;    // Perfis recebidos
    private string[] speechTxt;   // Falas recebidas
    private string[] actorNames;  // Nomes recebidos
    private int currentIndex;     // �ndice atual do di�logo

    public void StartDialogue(Sprite[] profiles, string[] speechTxt, string[] actorNames)
    {
        if (profiles == null || speechTxt == null || actorNames == null)
        {
            Debug.LogError("Os dados de di�logo s�o inv�lidos!");
            return;
        }

        this.profiles = profiles;
        this.speechTxt = speechTxt;
        this.actorNames = actorNames;
        currentIndex = 0;

        dialogueObj.SetActive(true);
        UpdateDialogueUI();
    }

    public void NextSentence()
    {
        if (currentIndex < speechTxt.Length - 1)
        {
            currentIndex++;
            UpdateDialogueUI();
        }
        else
        {
            EndDialogue();
        }
    }

    private void UpdateDialogueUI()
    {
        if (profiles.Length > currentIndex)
        {
            profileImage.sprite = profiles[currentIndex];
        }
        speechText.text = speechTxt[currentIndex];
        actorNameText.text = actorNames[currentIndex];
    }

    private void EndDialogue()
    {
        dialogueObj.SetActive(false);
        profiles = null;
        speechTxt = null;
        actorNames = null;
    }
}
