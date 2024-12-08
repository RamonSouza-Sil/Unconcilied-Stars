using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar a cena

public class Dialogo2 : MonoBehaviour
{
    [Header("Configurações do Diálogo")]
    public Sprite profile; // Sprite do NPC
    [TextArea(2, 5)] public string[] speechTxt; // Falas do NPC
    public string actorName; // Nome do NPC

    [Header("Configurações de Interação")]
    public LayerMask playerLayer; // Camada do jogador
    [SerializeField] private float radius = 2f; // Raio de interação

    [Header("Cena a Carregar")]
    public string cenaParaCarregar = "Cena5p2"; // Nome da cena a ser carregada ao final do diálogo

    private DialogoControl dc; // Controle de diálogo
    private bool onRadius; // Jogador está no raio de interação?
    private bool dialogoFinalizado = false; // Diálogo terminou?

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>(); // Busca o controlador de diálogo
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
        // Inicia o diálogo
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !dc.dialogueObj.activeSelf)
        {
            dc.Speech(profile, speechTxt, actorName);
        }

        // Avança o diálogo
        if (Input.GetKeyDown(KeyCode.E) && dc.dialogueObj.activeSelf)
        {
            dc.NextSentence();
        }

        // Verifica se o diálogo terminou
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
        dialogoFinalizado = true; // Marca que o diálogo terminou
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius); // Mostra o raio no editor
    }
}