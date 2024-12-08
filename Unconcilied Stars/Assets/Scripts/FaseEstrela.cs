using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseEstrela : MonoBehaviour
{
    [SerializeField]
    string nomeFase;  // O nome da próxima fase que será carregada

    private bool fasePermitida = false;  // Verifica se a fase pode ser pulada

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player" e se a fase é permitida
        if (collision.CompareTag("Player") && fasePermitida)
        {
            NextFase();
        }
    }

    public void ColetarItem()
    {
        // Quando o jogador coleta o item, a fase pode ser pulada
        fasePermitida = true;
    }

    private void NextFase()
    {
        // Carrega a próxima fase
        SceneManager.LoadScene(this.nomeFase);
    }
}

