using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    public RoomInfo info;

    public void Setup(RoomInfo info)
    {
        this.info = info;
        roomName.text = info.Name;
    }

    public void OnClick()
    {
        MainClass.Instance.JoinRoom(info);
    }
}
