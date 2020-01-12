using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class BulletExplosion : MonoBehaviour
{
    PhotonView pv;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>(); 
        pv.RPC("DestoryBullet" , RpcTarget.All);
    }

    void OnCollisionEnter (Collision Col)
    {
        if (pv.IsMine)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GameObject Explosion = PhotonNetwork.Instantiate("Explosion" , transform.position , Quaternion.identity , 0 ) as GameObject;
            
        }
    }

    [PunRPC]
    public void DestoryBullet()
    {
        Destroy (gameObject, 2f);
    }


    

}
