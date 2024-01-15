using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{ 
    // Статический список выделенных объектов
    public List<GameObject> listplayer = new List<GameObject>();
    
    private void OnTriggerEnter(Collider other)
    {   

        
        if (other.CompareTag("Player"))
        {
            if (!listplayer.Contains(other.gameObject))
            {
               
               
                listplayer.Add(other.gameObject);
                
            }
        }
        else
        {
            Debug.Log("Кінець фільму");
        }
    }


   
}