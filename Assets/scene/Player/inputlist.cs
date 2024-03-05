using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputlist : MonoBehaviour
{
    public GameObject Stroke;

    public List<GameObject> Listplayer;
    public bool flag = true;

    void Start()
    {
        // Возможно, здесь вам не нужно добавлять Stroke в Listplayer
    }

    void Update()
    {
        GameObject listplayer = GameObject.FindGameObjectWithTag("Plane");
        Quadro list = listplayer.GetComponent<Quadro>();
        Listplayer = list.selectedObjects;

        if (Listplayer.Contains(gameObject) && (flag))
        {
            
            SpawnStroke();
            flag = false;
        }

       

        if (!Listplayer.Contains(gameObject) && (transform.childCount > 0))
        {
            DestroyStroke();
        }
    }

    private void SpawnStroke( )
    {
        Transform pointgus = gameObject.transform;
        GameObject SpawnStroke = Instantiate(Stroke, pointgus.position, pointgus.rotation);
        SpawnStroke.transform.parent = gameObject.transform;
        flag = false;
    }

    public void DestroyStroke()
    {
        
            Transform childTransform = transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            flag = true;
            Destroy(childObject);
        
    }
}