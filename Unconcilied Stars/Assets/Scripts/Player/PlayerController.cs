using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool canMove = true; // Controle do movimento

    public Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Start()
    {
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

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * speed;

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

        if (direction.y > 0 && direction.x == 0)
        {
            resertLayer();
            anim.SetLayerWeight(1, 1);
        }

        if (direction.y < 0 && direction.x == 0)
        {
            resertLayer();
            anim.SetLayerWeight(0, 1);
        }

        if (direction != Vector2.zero)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    private void resertLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    }
}

