using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intercept_the_square : MonoBehaviour
{
    public static Color lsv_color = new Color(0.6F, 0.5F, 0.0F);
    public static Color fam_color = new Color(0.1f, 0.5f, 0.1f);
    public static Color lva_color = new Color(0.2F, 0.5F, 0.9F);
    public static Color sfr_color = new Color(0.3F, 0.3F, 0.5F);
    public static Color bal_color = new Color(0.4F, 0.2F, 0.5F);

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("square"))
        {
            if (transform.gameObject.name == "lsv")
                other.GetComponent<Renderer>().material.color = lsv_color;

            if (transform.gameObject.name == "fam")
                other.GetComponent<Renderer>().material.color = fam_color;

            if (transform.gameObject.name == "lva")
                other.GetComponent<Renderer>().material.color = lva_color;

            if (transform.gameObject.name == "sfr")
                other.GetComponent<Renderer>().material.color = sfr_color;

            if (transform.gameObject.name == "bal")
                other.GetComponent<Renderer>().material.color = bal_color;
        }
    }
}
