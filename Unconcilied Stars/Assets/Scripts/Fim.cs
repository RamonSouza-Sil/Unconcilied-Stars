using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{
    void Update()
    {
        // Verifica se o jogador pressionou a tecla Espa�o
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarregarLabirinto(); // Chama a fun��o para carregar a cena "Labirinto"
        }
    }

    void CarregarLabirinto()
    {
        // Carrega a cena chamada "Labirinto"
        SceneManager.LoadScene("Menu");
    }
}
