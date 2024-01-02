using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class choisegang : MonoBehaviour
{
    public GameObject[] gameObjectArray;
    public int id = 0;
    public Transform spawnpoint;

    void Start()
    {
       Spawnunit(id);
    }

    // Update is called once per frame
    public void NextUnit() // Перекелючение юнитов вперед

    {   
        id ++;
        if (id <= 3)
        {   
           Spawnunit(id);
        }
        else 
        {
            id = 0;
            Spawnunit(id);
        }
    }
    public void Previous ()// Перекелючение юнитов Назад
    {
       id --;
        if (id < 0)
        {
            id = 3;
            Spawnunit(id);
        }
        else 
        {
           
            Spawnunit(id);
        } 
    }

    private void Spawnunit(int id) // Спавн юнитов
    {
           GameObject Unitobject = GameObject.FindWithTag("Unit");
            Destroy(Unitobject);
            
           Instantiate(gameObjectArray[id],spawnpoint.position,spawnpoint.rotation);
    }
    public void choise ()// Выбор
    {
        Debug.Log("Вы выбрали"+gameObjectArray[id]);
    }
}
