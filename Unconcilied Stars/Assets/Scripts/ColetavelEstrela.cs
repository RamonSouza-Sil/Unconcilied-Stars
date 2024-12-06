using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelEstrela : MonoBehaviour
{
    private GameObject jogador; // Refer�ncia ao jogador
    private bool itemColetado = false; // Para garantir que o item s� � coletado uma vez

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player"); // Encontra o jogador
    }

    void Update()
    {
        // Verifica se o jogador est� perto do item e se pressionou "Espa�o"
        if (Vector2.Distance(jogador.transform.position, transform.position) < 2f && !itemColetado)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ColetarItem(); // Coleta o item
            }
        }
    }

    void ColetarItem()
    {
        itemColetado = true; // Marca o item como coletado
        gameObject.SetActive(false); // Desativa o item, fazendo-o desaparecer
    }
}







