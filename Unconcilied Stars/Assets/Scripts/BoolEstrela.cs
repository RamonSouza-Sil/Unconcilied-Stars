using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BoolEstrela : MonoBehaviour
{
    [SerializeField]
    private GameObject objetoADestruir; // Objeto a ser destru�do ou desativado

    // M�todo que ser� chamado quando o objeto que cont�m esse script for destru�do
    private void OnDestroy()
    {
        // Verifica se o objeto a ser destru�do n�o � nulo
        if (objetoADestruir != null)
        {
            // Destr�i o objeto manualmente configurado no Inspector
            objetoADestruir.SetActive(false);
        }
    }
}