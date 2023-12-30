using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_x : MonoBehaviour
{
    private float scroll_wheel;
    void Update()
    {
        Vector3 rotate = transform.eulerAngles;
        scroll_wheel = Input.GetAxis("Mouse ScrollWheel");
        if (scroll_wheel < 0) rotate.x += 3.5f;
        if (scroll_wheel > 0) rotate.x -= 3.5f;
        transform.rotation = Quaternion.Euler(rotate);
    }
}
