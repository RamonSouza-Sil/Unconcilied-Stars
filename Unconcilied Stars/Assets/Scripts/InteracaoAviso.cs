using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteracaoAviso : MonoBehaviour
{
    public float raioDeInteracao = 2f; // Raio de intera��o
    public LayerMask playerLayer; // Camada do jogador
    public TMP_Text avisoTexto; // Texto de aviso de intera��o

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
            avisoTexto.text = "Pressione Espa�o para interagir";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interagir();
            }
        }
        else
        {
            avisoTexto.gameObject.SetActive(false); // Desativa o texto de aviso se n�o houver intera��o
        }
    }

    private void Interagir()
    {
        // L�gica de intera��o, o que acontece dependendo do tipo de objeto
        if (gameObject.CompareTag("NPC"))
        {
            // A��o para NPC
            Debug.Log("Iniciar di�logo com NPC");
        }
        else if (gameObject.CompareTag("Item"))
        {
            // A��o para o item (estrela), destr�i o objeto e desativa o aviso
            Debug.Log("Item coletado!");
            Destroy(gameObject); // Destr�i o objeto (estrela)
            avisoTexto.gameObject.SetActive(false); // Desativa o texto de aviso apenas para itens
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Para visualizar o raio de intera��o no editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioDeInteracao);
    }
}


