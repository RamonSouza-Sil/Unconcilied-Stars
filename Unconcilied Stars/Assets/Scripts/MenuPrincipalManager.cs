using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuPrincipalManager : MonoBehaviour
{
    public Button[] buttons; // Array para armazenar os botões do menu
    private int currentSelection = 0; // Índice da seleção atual do botão

    private void Start()
    {
        // Inicializar com o primeiro botão selecionado
        UpdateSelection();
    }

    private void Update()
    {
        // Navegação com as setas ou W, A, S, D
        float verticalInput = Input.GetAxisRaw("Vertical"); // Vertical é controlado pelas setas ou W, A, S, D

        if (verticalInput != 0)
        {
            // Se pressionado para cima ou para baixo, alterar a seleção
            if (verticalInput > 0)
                currentSelection--;
            else
                currentSelection++;

            // Limitar a seleção dentro do array de botões
            currentSelection = Mathf.Clamp(currentSelection, 0, buttons.Length - 1);

            UpdateSelection();
        }

        // Seleção com Enter
        if (Input.GetKeyDown(KeyCode.Return)) // Ou você pode usar GetKeyDown(KeyCode.KeypadEnter) se preferir
        {
            buttons[currentSelection].onClick.Invoke(); // Clica no botão selecionado
        }
    }

    private void UpdateSelection()
    {
        // Desmarcar a seleção anterior e selecionar o novo botão
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true; // Torna todos os botões interativos
        }

        // Destaque o botão atual
        buttons[currentSelection].Select(); // Seleciona o botão na interface
        buttons[currentSelection].interactable = false; // Torna o botão selecionado inativo, se preferir dar um destaque visual
    }
}