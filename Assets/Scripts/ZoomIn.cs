using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public GameObject camera_offset;
    public Console console;

    private float value_zoom = 1;

    private Vector3 last_position;  

    private bool isZoomed = false;
    private bool lastTriggerValue = false;

    private void Zoom()
    {
        if(!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, value_zoom))
        {
            last_position = camera_offset.transform.position;
            camera_offset.transform.Translate(Camera.main.transform.forward * value_zoom);
            isZoomed = true;
        }
    }

    private void Unzoom()
    {
        camera_offset.transform.position = last_position;
        isZoomed = false;
        
    }

    public void OnPadPressed(bool triggerValue)
    {
        console.AddLine("change zoom");
        if (isActiveAndEnabled && triggerValue && !lastTriggerValue)
        {
            if (isZoomed) Unzoom();
            else Zoom();
        }
        lastTriggerValue = triggerValue;
    }
}