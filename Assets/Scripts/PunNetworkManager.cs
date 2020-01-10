using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class PunNetworkManager : MonoBehaviourPunCallbacks
{
    public Button CreateRoomButton , JoinRoomButton , LeaveRoomButton;
    public InputField RoomNameField;

    public static PunNetworkManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PunNetworkManager>();
            }
            return instance;
        }
    }
    public static PunNetworkManager instance;
    public string roomName;

    #region  Behaviour
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("連線到Master!!!");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("成功加入! 房間名: " + PhotonNetwork.CurrentRoom.Name );
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        PhotonNetwork.AutomaticallySyncScene = true ; 
        Debug.Log("創建中...");
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    #region Function
    public void CreateRoom()
    {
        RoomOptions options = new RoomOptions
        {
            PublishUserId = true,
            MaxPlayers = 4,
            IsOpen = true,
            IsVisible = true
        };
        PhotonNetwork.CreateRoom(roomName , options);
    }

    public void JointRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion

    

}
