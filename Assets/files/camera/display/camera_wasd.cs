using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_wasd : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("w")) transform.Translate(0, 0, 0.1f);
        if (Input.GetKey("a")) transform.Translate(-0.1f, 0, 0);
        if (Input.GetKey("s")) transform.Translate(0, 0, -0.1f);
        if (Input.GetKey("d")) transform.Translate(0.1f, 0, 0);
    }
}
