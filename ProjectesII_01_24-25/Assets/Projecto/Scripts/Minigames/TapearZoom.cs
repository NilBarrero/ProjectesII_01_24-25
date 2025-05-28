using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapearZoom : MonoBehaviour
{
    public float zoomSpeed = 0.1f; 
    public float minZoom = 1f; 
    public float zoomDuration = 10f; 

    private float zoomTimer = 0f; 
    private bool isZooming = true; 

    void Update()
    {
        if (isZooming)
        {
            zoomTimer += Time.deltaTime;

            Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;

            if (Camera.main.orthographicSize <= minZoom)
            {
                Camera.main.orthographicSize = minZoom;
                isZooming = false; 
            }
        }
    }
}
