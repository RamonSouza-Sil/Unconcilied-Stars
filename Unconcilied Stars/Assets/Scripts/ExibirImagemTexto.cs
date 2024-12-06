using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExibirImagemTexto : MonoBehaviour
{
    public GameObject cenaImagem; // A imagem que aparecerá após a coleta
    public TMP_Text textoAviso; // O texto de aviso a ser exibido após a coleta
    public string mensagem = "Você coletou a estrela! Pressione espaço para continuar."; // Mensagem do aviso

    private bool imagemAtiva = false; // Verifica se a imagem está ativa ou não
    private GameObject jogador; // Referência ao jogador

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player"); // Encontra o jogador
        cenaImagem.SetActive(false); // A imagem começa desativada
        textoAviso.text = ""; // O texto começa vazio
    }

    void Update()
    {
        // Verifica se o jogador está perto do item (coletável) e se pressionou "Espaço"
        if (Vector2.Distance(jogador.transform.position, transform.position) < 2f && !imagemAtiva)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MostrarImagemTexto(); // Mostra a imagem e o texto
            }
        }

        // Caso a imagem e o texto já estejam visíveis, aguarda o jogador pressionar espaço para continuar
        if (imagemAtiva && Input.GetKeyDown(KeyCode.Space))
        {
            FecharImagemTexto(); // Fecha a imagem e o texto
        }
    }

    void MostrarImagemTexto()
    {
        cenaImagem.SetActive(true); // Ativa a imagem
        textoAviso.text = mensagem; // Exibe a mensagem de aviso
        imagemAtiva = true; // Marca que a imagem e o texto estão ativos
    }

    void FecharImagemTexto()
    {
        cenaImagem.SetActive(false); // Desativa a imagem
        textoAviso.text = ""; // Limpa o texto
        imagemAtiva = false; // Marca que a imagem e o texto estão desativados
    }
}
