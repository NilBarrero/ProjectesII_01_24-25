using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapearZoom : MonoBehaviour
{
    public float zoomSpeed = 0.1f; // Speed at which the camera zooms
    public float minZoom = 1f; // Minimum allowed zoom size
    public float zoomDuration = 10f; // Total time to complete the zoom

    private float zoomTimer = 0f; // Timer to track the time
    private bool isZooming = true; // Controls if the zoom is active

    void Update()
    {
        if (isZooming)
        {
            zoomTimer += Time.deltaTime;

            // Gradually decreases the camera's orthographic size to zoom out
            Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;

            // Limits the zoom to the minimum allowed size
            if (Camera.main.orthographicSize <= minZoom)
            {
                Camera.main.orthographicSize = minZoom;
                isZooming = false; // Stops zooming when the minimum size is reached
            }
        }
    }
}
