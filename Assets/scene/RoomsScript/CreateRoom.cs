using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void som()
    {
        CreatefRoom("jj"); // Зеленый видят только геи
        CreatefRoom("nn"); 
        
    }

    public void CreatefRoom(string name)
    {
        Debug.Log("created");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(name, roomOptions);
    }
}
