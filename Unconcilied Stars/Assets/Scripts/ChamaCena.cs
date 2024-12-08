using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ChamaCena : MonoBehaviour
{
    public GameObject cenaImagem;  // A imagem que ser� exibida ap�s o jogador tocar o objeto vazio
    public TMP_Text textoAviso;    // O texto a ser exibido
    public string mensagem = "Pressione espa�o para continuar."; // Mensagem de aviso ao jogador

    private bool interagido = false;  // Verifica se o jogador interagiu com o objeto

    PlayerController playerController;


    void Start()
    {
        cenaImagem.SetActive(false);  // A imagem come�a desativada
        textoAviso.text = "";         // O texto come�a vazio
    }

    void Update()
    {
        // Se o jogador interagiu e pressionou "Espa�o", fecha a imagem e o texto
        if (interagido && Input.GetKeyDown(KeyCode.Space))
        {
            FecharImagemTexto(); // Fecha a imagem e o texto
            Destroy(gameObject);  // Destr�i o objeto vazio para que ele n�o possa ser ativado novamente

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o jogador est� perto do objeto vazio
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

