using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intercept_the_square : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("square"))
        {
            if (transform.gameObject.name.Contains("lsv"))
                other.GetComponent<Renderer>().material.color = config.lsv_color;

            if (transform.gameObject.name == "fam")
                other.GetComponent<Renderer>().material.color = config.fam_color;

            if (transform.gameObject.name == "lva")
                other.GetComponent<Renderer>().material.color = config.lva_color;

            if (transform.gameObject.name == "sfr")
                other.GetComponent<Renderer>().material.color = config.sfr_color;

            if (transform.gameObject.name == "bal")
                other.GetComponent<Renderer>().material.color = config.bal_color;
        }
    }
}
