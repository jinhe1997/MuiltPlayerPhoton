using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SceneManager : MonoBehaviourPunCallbacks
{

    float CreatTime = 5f;
    #region  PhotonBehaviour
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject MyPlayer = PhotonNetwork.Instantiate( "PlayerPrefab/Player", new Vector3(0f, 5f , 0f) , Quaternion.identity);
        if(PhotonNetwork.CurrentRoom.PlayerCount <=  1)
        {
            GameObject Boss = PhotonNetwork.Instantiate( "PlayerPrefab/Boss", new Vector3(0f, 0f , 16.48f) , new Quaternion(0,180,0,0));
        }



        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            CameraController followScript = camera.GetComponent("CameraController") as CameraController;
            if (followScript != null)
            {
                followScript.target = MyPlayer;
            }
        }

    }
    #endregion

     void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            CreatTime -= Time.deltaTime;
            if (CreatTime <= 0)
            {
                CreatTime = Random.Range(3, 10);
                GameObject ManaGem = PhotonNetwork.Instantiate("Managem", new Vector3(Random.Range(-10f, 14f), 1.5f, Random.Range(-10f, 14f)), Quaternion.identity);
            }
        }
    }

}
