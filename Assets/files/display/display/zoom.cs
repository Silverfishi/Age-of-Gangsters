using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    private float scroll_wheel;
    void Update()
    {
        scroll_wheel = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, -(scroll_wheel * 20), -(scroll_wheel*7));
    }
}
