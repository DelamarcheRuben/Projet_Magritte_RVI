using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public GameObject camera_offset;
    public Console console;

    private float value_zoom = 4.5f;

    private Vector3 last_translate;  

    private bool isZoomed = false;
    private bool lastTriggerValue = false;

    private void Zoom()
    {
        if(!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, value_zoom))
        {
            last_translate = Camera.main.transform.forward * value_zoom;
            camera_offset.transform.Translate(Camera.main.transform.forward * value_zoom, Space.World);
            isZoomed = true;
        }
    }

    private void Unzoom()
    {
        camera_offset.transform.Translate(last_translate*-1, Space.World);
        isZoomed = false;
        
    }

    public void OnPadPressed(bool triggerValue)
    {
        if (isActiveAndEnabled && triggerValue && !lastTriggerValue)
        {
            if (isZoomed) Unzoom();
            else Zoom();
        }
        lastTriggerValue = triggerValue;
    }
}
