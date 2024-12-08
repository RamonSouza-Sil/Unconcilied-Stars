using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChaoQuebravel : MonoBehaviour
{
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obt�m o Collider2D e o SpriteRenderer do objeto
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o jogador entrou na �rea do trigger
        if (collision.CompareTag("Player"))
        {
            // N�o faz nada enquanto o jogador est� sobre o objeto
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Quando o jogador sair do trigger, desativa o trigger e o sprite
        if (collision.CompareTag("Player"))
        {
            DesativarTriggerESprite();
        }
    }

    // M�todo para desativar o trigger e o sprite
    void DesativarTriggerESprite()
    {
        // Desativa o trigger (mantendo o collider ativo para colis�es f�sicas)
        collider2D.isTrigger = false;

        // Desativa o sprite, fazendo com que o objeto desapare�a visualmente
        spriteRenderer.enabled = false;
    }
}
