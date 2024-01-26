using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public GameObject camera_offset;
    public Console console;

    private float value_zoom = 5;

    private bool isZoomed = false;
    private bool lastTriggerValue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Zoom()
    {
        camera_offset.transform.Translate(Camera.main.transform.forward*value_zoom);
        isZoomed = true;
    }

    private void Unzoom()
    {
        camera_offset.transform.Translate(Camera.main.transform.forward * (-value_zoom));
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
