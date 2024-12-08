using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class CarregarCena : MonoBehaviour
{
    void Update()
    {
        // Verifica se o jogador pressionou a tecla Espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarregarLabirinto(); // Chama a função para carregar a cena "Labirinto"
        }
    }

    void CarregarLabirinto()
    {
        // Carrega a cena chamada "Labirinto"
        SceneManager.LoadScene("Labirinto");
    }
}
