using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minZoomDist;
    [SerializeField] private float maxZoomDist;

    [SerializeField] private float zoomSpeed;
    [SerializeField ]private float zoomModifier;

    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
        
    }

    private void Update()
    {
        Zoom();
    }


    private void Zoom()
    {
        zoomModifier = Input.GetAxis("Mouse ScrollWheel");


        float dist = Vector3.Distance(transform.position, cam.transform.position);

        if (dist < minZoomDist && zoomModifier > 0f)
        {
            return;
        }
        else if (dist > maxZoomDist && zoomModifier < 0f)
        {
            return;
        }

        cam.transform.position += cam.transform.forward * zoomModifier * zoomSpeed;

    }
}
