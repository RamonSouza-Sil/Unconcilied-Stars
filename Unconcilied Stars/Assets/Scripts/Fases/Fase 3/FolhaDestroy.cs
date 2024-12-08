using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FolhaDestroy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject, 2.5f);
        
        
    }
}
