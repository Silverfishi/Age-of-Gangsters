using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unit_spawner: MonoBehaviour
{
    public GameObject lsv_unit_prefab;
    public static GameObject fam_unit_prefab;
    public static GameObject lva_unit_prefab;
    public static GameObject bal_unit_prefab;

    public static List<int> lsv_units = new List<int>(){};
    public static List<int> fam_units = new List<int>(){};
    public static List<int> lva_units = new List<int>(){};
    public static List<int> bal_units = new List<int>(){};

    //public Text lsv_units_text;
    //public Text fam_units_text;
    //public Text lva_units_text;
    //public Text bal_units_text;

    void Start()
    {
        Instantiate(lsv_unit_prefab, new Vector3(0, 0, 0), Quaternion.identity);


        lsv_units.Add(10);
        //fam_units.Add(10);
        //lva_units.Add(10);
        //bal_units.Add(10);
    }
    void Update ()
    {
        //lsv_units_text.text = lsv_units[0].ToString();
        //fam_units_text.text = fam_units[0].ToString();
        //lva_units_text.text = fam_units[0].ToString();
        //bal_units_text.text = fam_units[0].ToString();
    }
}
