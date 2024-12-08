using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteracaoAviso : MonoBehaviour
{
    public float raioDeInteracao = 2f; // Raio de interação
    public LayerMask playerLayer; // Camada do jogador
    public TMP_Text avisoTexto; // Texto de aviso de interação

    private void Update()
    {
        VerificarInteracao();
    }

    private void VerificarInteracao()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, raioDeInteracao, playerLayer);

        if (hit != null)
        {
            avisoTexto.gameObject.SetActive(true); // Ativa o texto de aviso
            avisoTexto.text = "Pressione Espaço para interagir";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interagir();
            }
        }
        else
        {
            avisoTexto.gameObject.SetActive(false); // Desativa o texto de aviso se não houver interação
        }
    }

    private void Interagir()
    {
        // Lógica de interação, o que acontece dependendo do tipo de objeto
        if (gameObject.CompareTag("NPC"))
        {
            // Ação para NPC
            Debug.Log("Iniciar diálogo com NPC");
        }
        else if (gameObject.CompareTag("Item"))
        {
            // Ação para o item (estrela), destrói o objeto e desativa o aviso
            Debug.Log("Item coletado!");
            Destroy(gameObject); // Destrói o objeto (estrela)
            avisoTexto.gameObject.SetActive(false); // Desativa o texto de aviso apenas para itens
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Para visualizar o raio de interação no editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioDeInteracao);
    }
}


