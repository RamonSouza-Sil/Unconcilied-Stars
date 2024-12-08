using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class ReiniciarCena : MonoBehaviour
{
    public string nomeCena = "Morte1";  // Nome da cena que você quer carregar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            CarregarCena();
        }
    }

    void CarregarCena()
    {
        // Carrega a cena com o nome especificado
        SceneManager.LoadScene(nomeCena);
    }
}

