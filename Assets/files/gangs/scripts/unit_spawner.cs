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

    void Start()
    {
        Instantiate(lsv_unit_prefab, new Vector3(20, 0, 20), Quaternion.identity);


        lsv_units.Add(10);
    }
}
