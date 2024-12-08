using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapa5pt2 : MonoBehaviour
{
    [Header("Nome da Cena")]
    public string Mapa5p2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CarregarCena();
        }
    }

    private void CarregarCena()
    {
        if (!string.IsNullOrEmpty(Mapa5p2))
        {
            SceneManager.LoadScene(Mapa5p2);
        }
        else
        {
            Debug.LogWarning("Nenhuma cena foi definida para carregar!");
        }
    }
}
