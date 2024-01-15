using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnpoint : MonoBehaviour
{
public GameObject objectToSpawn;
//public bool flag = true; 
public List<GameObject> Listplayer;


void Update()
{   
    GameObject listplayer = GameObject.FindGameObjectWithTag("Plane");
    Quadro list = listplayer.GetComponent<Quadro>();     
    Listplayer = list.selectedObjects;
    
    SpawnObjectAtMousePosition();
    
}
public void SpawnObjectAtMousePosition()
    {  
      
      GameObject pointObject = GameObject.FindGameObjectWithTag("Point");

      if (Listplayer.Count > 0)
    {
      
      
    
       if (Input.GetMouseButtonUp(1))
       {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            
            if (pointObject == null )
              {
                Vector3 spawnPosition = hit.point;
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                
              }            
            if (pointObject != null)
            {    
                Debug.Log("Ку");
                 Destroy(pointObject);
                Vector3 spawnPosition = hit.point;
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
            
        }}
       }
    }
}
