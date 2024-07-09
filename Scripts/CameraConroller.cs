using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    public float PanSpeed = 25f;
    public float PanBorderThickness =10F;
    public float ScrollSpeed = 5f;
    float MinY = 10f;
    float MaxY = 80f;
    void Update()
    {
        if (gameManager.GameOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKey("w") )
        {
            transform.Translate( Vector3.left * PanSpeed*Time.deltaTime,Space.World);
        }
        if (Input.GetKey("s") )
        {
            transform.Translate( Vector3.right * PanSpeed*Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate( Vector3.back * PanSpeed*Time.deltaTime,Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate( Vector3.forward * PanSpeed*Time.deltaTime,Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, MinY,MaxY);
        pos.y-=scroll *1000*ScrollSpeed*Time.deltaTime;
        transform.position = pos;
    }
}
