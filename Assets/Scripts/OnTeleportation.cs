using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTeleportation : MonoBehaviour
{
    // Start is called before the first frame update.
    public GameObject camera_offset;
    private float position_y;
    void Start()
    {
        position_y = camera_offset.transform.position.y;
    }

    // Update is called once per frame
    public void onTeleport()
    {
        camera_offset.transform.position = new  Vector3(0, position_y, 0);
    }
}
