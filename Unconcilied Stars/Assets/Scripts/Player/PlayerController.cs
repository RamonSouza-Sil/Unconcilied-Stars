using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool canMove = true; // Controle do movimento

    public Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    ChamaCena ChamaCena;

    void Start()
    {
        // associa os componentes do player com as variaveis
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
        if (!canMove) // Verifica se o movimento está bloqueado
        {
            rb.velocity = Vector2.zero; // Impede o movimento do jogador
            anim.SetBool("Walking", false); // Interrompe animação de movimento
            return;
        }

        // movimentação do jogador via "horizontal e vertical" da unity
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * speed;

        // Verifica a direção do jogador e muda o sprite de lado
        if (direction.x != 0)
        {
            resertLayer();
            anim.SetLayerWeight(2, 1);

            if (direction.x > 0)
            {
                sprite.flipX = false;
            }
            else if (direction.x < 0)
            {
                sprite.flipX = true;
            }
        }

        //prioridade das animações para cima
        if (direction.y > 0 && direction.x == 0)
        {
            resertLayer();
            anim.SetLayerWeight(1, 1);
        }
        //prioridade das animações para baixo
        if (direction.y < 0 && direction.x == 0)
        {
            resertLayer();
            anim.SetLayerWeight(0, 1);
        }

        // força animação de movimento
        if (direction != Vector2.zero)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    // distribui a prioridade de animações dentro da janela de animation
    private void resertLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    }
}

