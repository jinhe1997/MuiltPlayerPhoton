  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using DG.Tweening;

public class PunCanvasManager : MonoBehaviourPunCallbacks
{
    public Button CreateRoomButton , JoinRoomButton , LeaveRoomButton;
    public InputField RoomNameField;
    public RectTransform FinishPanel;

    #region  Function
    public void onAnyButtonClick()
    {
        CreateRoomButton.interactable = false;
        JoinRoomButton.interactable = false;
    }

    public void TypingRoomName()
    {
        PunNetworkManager.instance.roomName = RoomNameField.text;
    }

    public void RestartGame()
    {
        FinishPanel.DOScale(0,1);
        PhotonNetwork.LeaveRoom();
    }
    #endregion

    #region PhotonBehaviour
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        CreateRoomButton.interactable = true;
        JoinRoomButton.interactable = true;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode , message);
        CreateRoomButton.interactable = true;
        JoinRoomButton.interactable = true;
        Debug.Log("無法找到房間或發生一些問題!");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        CreateRoomButton.gameObject.SetActive(false);
        JoinRoomButton.gameObject.SetActive(false);
        RoomNameField.gameObject.SetActive(false);
        LeaveRoomButton.gameObject.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        CreateRoomButton.gameObject.SetActive(true);
        JoinRoomButton.gameObject.SetActive(true);
        RoomNameField.gameObject.SetActive(true);
        LeaveRoomButton.gameObject.SetActive(false);
    }
    #endregion


}

