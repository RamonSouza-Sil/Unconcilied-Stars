using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

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
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * speed;


        if(direction.x != 0)
        {
            //setando a prioridade das layers do animator
            resertLayer();
            anim.SetLayerWeight(2, 1);

            //flip do sprite de lados para movimenta��o dos lados
            if(direction.x > 0)
            {
                sprite.flipX = false;
            }
            else if(direction.x < 0)
            {
                sprite.flipX=true;
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

        //condi��o para mudan�a de anima��o, "walking" � a fun��o dentro do animator
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
