using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogoDuplo : MonoBehaviour
{
    public Sprite[] profiles;  // Perfis correspondentes às falas
    public string[] speechTxt; // Textos do diálogo
    public string[] actorNames; // Nomes dos personagens

    public LayerMask playerLayer;
    [SerializeField]
    public float radius;

    private DialogoControl2 dc; // Aqui corrigimos o tipo do controlador
    private bool onRadius;

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl2>(); // Procura o controlador na cena
        if (dc == null)
        {
            Debug.LogError("DialogoControl2 não encontrado na cena!");
        }
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        onRadius = hit != null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadius && !dc.dialogueObj.activeSelf)
        {
            // Envia todas as informações ao controlador de diálogo
            dc.StartDialogue(profiles, speechTxt, actorNames);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dc.dialogueObj.activeSelf)
        {
            dc.NextSentence(); // Avança para a próxima frase
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

