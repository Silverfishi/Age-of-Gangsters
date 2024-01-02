using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_y : MonoBehaviour
{
    private bool rotate = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(2)) rotate = true;
        if (Input.GetMouseButtonUp  (2)) rotate = false;

        if (rotate) 
            transform.Rotate(0, Input.GetAxis("Mouse X") * 3, 0);
    }
}
