using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LifeControll : MonoBehaviour
{
    public MenuPrincipalManager Menu;

    public int vida;
    public int vidaMax;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    void Update()
    {
        Vida();
    }
    
    void Vida()
    {
        if (vida > vidaMax)
        {
            vida = vidaMax;    
        }

        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if (i <= vidaMax)
            {
                coracao[i].enabled = true;
            }

            else
            {
                coracao[i].enabled = false;
            }
        }

        if (vida == 0)
        {
            GetComponent<PlayerController>().enabled = false;
            Destroy(gameObject, 2.5f);
            SceneManager.LoadScene("Morte");
        }
    }
}