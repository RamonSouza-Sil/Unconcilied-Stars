using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SFXController : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField]private AudioSource fundoMusical;

    

    public void LigarDesligarSFX()
    {
        estadoSom = !estadoSom;
        if (estadoSom == true)
        {
            AudioListener.volume = 1.0f;
        }
        else
        {
            AudioListener.volume = 0.0f;
        }
    }
}
