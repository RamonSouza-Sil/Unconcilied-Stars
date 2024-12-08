using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para carregar a cena

public class Dialogo2 : MonoBehaviour
{
    [Header("Configura��es do Di�logo")]
    public Sprite profile; // Sprite do NPC
    [TextArea(2, 5)] public string[] speechTxt; // Falas do NPC
    public string actorName; // Nome do NPC

    [Header("Configura��es de Intera��o")]
    public LayerMask playerLayer; // Camada do jogador
    [SerializeField] private float radius = 2f; // Raio de intera��o

    [Header("Cena a Carregar")]
    public string cenaParaCarregar = "Cena5p2"; // Nome da cena a ser carregada ao final do di�logo

    private DialogoControl dc; // Controle de di�logo
    private bool onRadius; // Jogador est� no raio de intera��o?
    private bool dialogoFinalizado = false; // Di�logo terminou?

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>(); // Busca o controlador de di�logo
    }

    private void FixedUpdate()
    {
        VerificarInteracao();
    }

    private void VerificarInteracao()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if (hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void Update()
    {
        // Inicia o di�logo
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !dc.dialogueObj.activeSelf)
        {
            dc.Speech(profile, speechTxt, actorName);
        }

        // Avan�a o di�logo
        if (Input.GetKeyDown(KeyCode.E) && dc.dialogueObj.activeSelf)
        {
            dc.NextSentence();
        }

        // Verifica se o di�logo terminou
        if (!dc.dialogueObj.activeSelf && dialogoFinalizado)
        {
            CarregarCena(); // Carrega a cena configurada
        }
    }

    private void CarregarCena()
    {
        if (!string.IsNullOrEmpty(cenaParaCarregar))
        {
            SceneManager.LoadScene(cenaParaCarregar);
        }
        else
        {
            Debug.LogWarning("Nenhuma cena foi definida para carregar!");
        }
    }

    public void MarcarDialogoComoFinalizado()
    {
        dialogoFinalizado = true; // Marca que o di�logo terminou
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius); // Mostra o raio no editor
    }
}