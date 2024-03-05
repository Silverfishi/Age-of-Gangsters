using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;



public class diplomatypanel : MonoBehaviour
{   public Button[] Diplomaty;
    public GameObject Diplomatypanel;
    // Start is called before the first frame update
    void Start()
    {
        
 
      Diplomatypanel.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Diplomatypanel.SetActive(false);
           
        }
    
    }
    public void ClicPeace()
    {
        Diplomaty[0].image.color = Color.green;
        Diplomaty[1].image.color = Color.white;
        Diplomaty[2].image.color = Color.white;
    }
    public void ClicNeitral()
    {
        Diplomaty[0].image.color = Color.white;
        Diplomaty[1].image.color = Color.yellow;
        Diplomaty[2].image.color = Color.white;
    }
    public void ClicWar()
    {
        Diplomaty[0].image.color = Color.white;
        Diplomaty[2].image.color = Color.red;
        Diplomaty[1].image.color = Color.white;
    }
    public void Diplomation()
    {
        
 
        Diplomatypanel.SetActive(true);
    }
}
