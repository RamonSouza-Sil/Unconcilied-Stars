using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigeerDamage : MonoBehaviour
{

    public LifeControll Heart;
    private void OnCollisionEnter2D(Collision2D collision) //verifica a colisão do player com o gameobject associado com este script
    {
        if (collision.gameObject.tag == "Player")
        {
            Heart.vida--; //diminui a vida do player em -1
        }
    }
}