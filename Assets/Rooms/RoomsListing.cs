using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomsListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private GetRoomsList grl;

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        Debug.Log(_roomList[0]);
        foreach(RoomInfo info in _roomList)
        {
            Debug.Log(info.Name);
            GetRoomsList ggrl = Instantiate(grl, _content);
            if(ggrl != null)
            {
                ggrl.SetRoomInfo(info); 
            }
        }
    }
}
