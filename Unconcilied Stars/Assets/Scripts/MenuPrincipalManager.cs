using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuPrincipalManager : MonoBehaviour
{
    public Button[] buttons; // Array para armazenar os bot�es do menu
    private int currentSelection = 0; // �ndice da sele��o atual do bot�o

    private void Start()
    {
        // Inicializar com o primeiro bot�o selecionado
        UpdateSelection();
    }

    private void Update()
    {
        // Navega��o com as setas ou W, A, S, D
        float verticalInput = Input.GetAxisRaw("Vertical"); // Vertical � controlado pelas setas ou W, A, S, D

        if (verticalInput != 0)
        {
            // Se pressionado para cima ou para baixo, alterar a sele��o
            if (verticalInput > 0)
                currentSelection--;
            else
                currentSelection++;

            // Limitar a sele��o dentro do array de bot�es
            currentSelection = Mathf.Clamp(currentSelection, 0, buttons.Length - 1);

            UpdateSelection();
        }

        // Sele��o com Enter
        if (Input.GetKeyDown(KeyCode.Return)) // Ou voc� pode usar GetKeyDown(KeyCode.KeypadEnter) se preferir
        {
            buttons[currentSelection].onClick.Invoke(); // Clica no bot�o selecionado
        }
    }

    private void UpdateSelection()
    {
        // Desmarcar a sele��o anterior e selecionar o novo bot�o
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true; // Torna todos os bot�es interativos
        }

        // Destaque o bot�o atual
        buttons[currentSelection].Select(); // Seleciona o bot�o na interface
        buttons[currentSelection].interactable = false; // Torna o bot�o selecionado inativo, se preferir dar um destaque visual
    }
}