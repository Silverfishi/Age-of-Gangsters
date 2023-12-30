using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class GetRoomsList : MonoBehaviour
{
    [SerializeField]
     private Text  _text;

    public void SetRoomInfo(RoomInfo roominfo)
    {
        _text.text = roominfo.MaxPlayers + "/" + roominfo.Name;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Кашир гей Sidor tozhe,");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
