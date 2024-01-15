using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int speed = 2;
    
    public bool flag = false;
    public List<GameObject> Listplayer;
    void Update()
    {   
        
          

       GameObject listplayer = GameObject.FindGameObjectWithTag("Plane");
        Quadro list = listplayer.GetComponent<Quadro>();     
        Listplayer = list.selectedObjects;
        
       
       if (GameObject.FindGameObjectWithTag("Point") != null)
       {
        GameObject pointObject = GameObject.FindGameObjectWithTag("Point");
        Transform pointTransform = pointObject.transform;
       
       if (pointObject != null && Listplayer.Contains(gameObject)) // ПКМ та флаг не встановлений
        {
            
            flag = true;
        }

        if (flag)
        {
            MovePlayerToSpawnedObject(pointTransform, pointObject);
        }
    }}

   

    void MovePlayerToSpawnedObject(Transform pointTransform , GameObject pointObject)
    {
        
        Transform playerTransform = gameObject.transform;

        

        // Определите направление к точке
        Vector3 directionToPoint = (pointTransform.position - playerTransform.position).normalized;

        // Поверніть гравця в напрямку точки
        Quaternion PointRotation = Quaternion.LookRotation(directionToPoint);
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, PointRotation, Time.deltaTime * 5f);

        // Визначте відстань між гравцем і точкою
        float distanceToPoint = Vector3.Distance(playerTransform.position, pointTransform.position);

        // Переміщайте гравця в напрямку точки, але зупиняйте його, коли досягаєте точки
        playerTransform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (distanceToPoint < 1.1f)
        {
            Destroy(pointObject);
            flag = false; // Скидаємо флаг, коли досягнута точка
        }
    }
}