using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ChamaCena : MonoBehaviour
{
    public GameObject cenaImagem;  // A imagem que será exibida após o jogador tocar o objeto vazio
    public TMP_Text textoAviso;    // O texto a ser exibido
    public string mensagem = "Pressione espaço para continuar."; // Mensagem de aviso ao jogador

    private bool interagido = false;  // Verifica se o jogador interagiu com o objeto

    PlayerController playerController;


    void Start()
    {
        cenaImagem.SetActive(false);  // A imagem começa desativada
        textoAviso.text = "";         // O texto começa vazio
    }

    void Update()
    {
        // Se o jogador interagiu e pressionou "Espaço", fecha a imagem e o texto
        if (interagido && Input.GetKeyDown(KeyCode.Space))
        {
            FecharImagemTexto(); // Fecha a imagem e o texto
            Destroy(gameObject);  // Destrói o objeto vazio para que ele não possa ser ativado novamente

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o jogador está perto do objeto vazio
        if (other.CompareTag("Player") && !interagido)
        {
            interagido = true;  // Marca como interagido
            MostrarImagemTexto(); // Exibe a imagem e o texto
            playerController.speed = 5;
        }
    }

    void MostrarImagemTexto()
    {
        cenaImagem.SetActive(true);  // Ativa a imagem
        textoAviso.text = mensagem;  // Exibe a mensagem de aviso
        playerController.speed = 0;

    }

    void FecharImagemTexto()
    {
        cenaImagem.SetActive(false);  // Desativa a imagem
        textoAviso.text = "";         // Limpa o texto
        playerController.speed = 3;
    }
}

