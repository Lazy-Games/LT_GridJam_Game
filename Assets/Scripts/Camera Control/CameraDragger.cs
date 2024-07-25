using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragger : MonoBehaviour
{
    private Vector3 dragOrigin;
    public float zoomSpeed = 0.5f;
    public float minZoom = 2f;
    public float maxZoom = 10f;

    void Update()
    {
        // Dragging the camera
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += difference;
        }

        // Zooming the camera
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize -= scrollData * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
    }
}
