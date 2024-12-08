using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class AtivadorDeNoite : MonoBehaviour
{
    public GameObject cenaImagem;


    private bool interagido = false;

    void Start()
    {
        cenaImagem.SetActive(false);  // A imagem começa desativada

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o jogador está perto do objeto vazio
        if (other.CompareTag("Player") && !interagido)
        {
            interagido = true;  // Marca como interagido
            MostrarImagemTexto(); // Exibe a imagem e o texto
        }
    }

    void MostrarImagemTexto()
    {
        cenaImagem.SetActive(true);  // Ativa a imagem

    }


}



