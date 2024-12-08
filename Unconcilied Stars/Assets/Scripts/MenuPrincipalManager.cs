using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeLevel;
    [SerializeField] private GameObject painelMenuInicial;
    
    public void Jogar()
    {
        SceneManager.LoadScene(nomeLevel);
    }

    public void sairJogo()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}