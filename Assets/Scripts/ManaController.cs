using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    PhotonView Pv;
    void Start()
    {
        Pv = GetComponent<PhotonView>();
        Pv.RPC("DestoryMana", RpcTarget.All);
    }


    void OnCollisionEnter(Collision Col)
    {
        if (Pv.IsMine && Col.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GameObject Explosion = PhotonNetwork.Instantiate("ExplosionStar", transform.position, Quaternion.identity, 0) as GameObject;

        }
    }

    [PunRPC]
    public void DestoryMana()
    {
        Destroy(gameObject, 3.5f);
    }

}
