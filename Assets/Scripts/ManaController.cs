using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ManaController : MonoBehaviour
{
    public int mana;
    PhotonView Pv;

    void Start()
    {
        
    }

    void Update()
    {


        void OnCollisionEnter(Collision Col)
        {
            if (Pv.IsMine)
            {
                mana++;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                GameObject Explosion = PhotonNetwork.Instantiate("Explosion", transform.position, Quaternion.identity, 0) as GameObject;

            }
        }

    }
}
