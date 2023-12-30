using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        // Подключение к серверам Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Подключено к серверу Photon Master");
        
        // При необходимости вы можете присоединиться к лобби здесь
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Присоединено к лобби Photon");
        //SceneManager.LoadScene("lobby");
        CreatefRoom("nn"); 
    }
    public void som()
    {
        CreatefRoom("jj"); // Зеленый видят только геи
        
    }

    public void CreatefRoom(string name)
    {
        Debug.Log("created");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(name, roomOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
