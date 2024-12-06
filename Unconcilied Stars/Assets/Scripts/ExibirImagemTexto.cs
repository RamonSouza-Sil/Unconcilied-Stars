using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExibirImagemTexto : MonoBehaviour
{
    public GameObject cenaImagem; // A imagem que aparecer� ap�s a coleta
    public TMP_Text textoAviso; // O texto de aviso a ser exibido ap�s a coleta
    public string mensagem = "Voc� coletou a estrela! Pressione espa�o para continuar."; // Mensagem do aviso

    private bool imagemAtiva = false; // Verifica se a imagem est� ativa ou n�o
    private GameObject jogador; // Refer�ncia ao jogador

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player"); // Encontra o jogador
        cenaImagem.SetActive(false); // A imagem come�a desativada
        textoAviso.text = ""; // O texto come�a vazio
    }

    void Update()
    {
        // Verifica se o jogador est� perto do item (colet�vel) e se pressionou "Espa�o"
        if (Vector2.Distance(jogador.transform.position, transform.position) < 2f && !imagemAtiva)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MostrarImagemTexto(); // Mostra a imagem e o texto
            }
        }

        // Caso a imagem e o texto j� estejam vis�veis, aguarda o jogador pressionar espa�o para continuar
        if (imagemAtiva && Input.GetKeyDown(KeyCode.Space))
        {
            FecharImagemTexto(); // Fecha a imagem e o texto
        }
    }

    void MostrarImagemTexto()
    {
        cenaImagem.SetActive(true); // Ativa a imagem
        textoAviso.text = mensagem; // Exibe a mensagem de aviso
        imagemAtiva = true; // Marca que a imagem e o texto est�o ativos
    }

    void FecharImagemTexto()
    {
        cenaImagem.SetActive(false); // Desativa a imagem
        textoAviso.text = ""; // Limpa o texto
        imagemAtiva = false; // Marca que a imagem e o texto est�o desativados
    }
}
