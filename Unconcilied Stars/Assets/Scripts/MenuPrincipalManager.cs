using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeLevel; // colocamos o nome do level 
    [SerializeField] private GameObject painelMenuInicial; // colocamos o gameobject do menu principal
    
    // chama a cena 1 do jogo quando clicar no botão jogar (dentro da unity)
    public void Jogar()
    {
        SceneManager.LoadScene(nomeLevel); 
    }

    // o jogo fecha
    public void sairJogo()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}