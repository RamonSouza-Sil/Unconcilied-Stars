using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PulaFase : MonoBehaviour
{
    [SerializeField]
    string nomeFase;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        NextFase();
    }

    private void NextFase()
    {
        SceneManager.LoadScene(this.nomeFase);

    }


}
