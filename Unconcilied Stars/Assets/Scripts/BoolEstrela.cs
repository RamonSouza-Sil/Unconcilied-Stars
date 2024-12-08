using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BoolEstrela : MonoBehaviour
{
    [SerializeField]
    private GameObject objetoADestruir; // Objeto a ser destruído ou desativado

    // Método que será chamado quando o objeto que contém esse script for destruído
    private void OnDestroy()
    {
        // Verifica se o objeto a ser destruído não é nulo
        if (objetoADestruir != null)
        {
            // Destrói o objeto manualmente configurado no Inspector
            objetoADestruir.SetActive(false);
        }
    }
}