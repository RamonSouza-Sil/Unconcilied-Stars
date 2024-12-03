using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasegue : MonoBehaviour
{
    public Transform player; 
    public BoxCollider2D mapBounds; 

    private float minX, maxX, minY, maxY;
    private float camHalfHeight, camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;

        Bounds bounds = mapBounds.bounds;
        minX = bounds.min.x + camHalfWidth;
        maxX = bounds.max.x - camHalfWidth;
        minY = bounds.min.y + camHalfHeight;
        maxY = bounds.max.y - camHalfHeight;
    }

    void Update()
    {
        if (player != null)
        {
            float targetX = Mathf.Clamp(player.position.x, minX, maxX);
            float targetY = Mathf.Clamp(player.position.y, minY, maxY);

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}