using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BossController : MonoBehaviour
{
    public Animator BossAni;
    float CreatTime = 5f;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            CreatTime -= Time.deltaTime;
            if (CreatTime <= 0)
            {
                BossAni.SetTrigger("Jump");
                CreatTime = Random.Range(3, 10);
                GameObject ManaGem = PhotonNetwork.Instantiate("PlayerPrefab/Enemy", new Vector3(Random.Range(-10f, 14f), 1.5f, Random.Range(-10f, 14f)), Quaternion.identity);
            }
        }
    }
        
}
