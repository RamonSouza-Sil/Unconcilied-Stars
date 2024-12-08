using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LifeControll : MonoBehaviour
{
    public MenuPrincipalManager Menu;

    public int vida; // vida atual do player
    public int vidaMax; //máximo de vida que o player pode ter

    public Image[] coracao; // sprites da vida
    public Sprite cheio;// sprites da vida cheia
    public Sprite vazio;// sprites da vida vazia

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

        for (int i = 0; i < coracao.Length; i++) // verifica os corações e desabilita os sprites deles
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

        if (vida == 0) // aciona tela de morte
        {
            GetComponent<PlayerController>().enabled = false;
            Destroy(gameObject, 2.5f);
            SceneManager.LoadScene("Morte");
        }
    }
}