using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject Explosion;
    public int MonsterHealth;
    PhotonView Pv ;
    public Animator BossAni;
    public Text TextHealth;

    void Start()
    {
        Pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        Pv.RPC("BossHealthStream" , RpcTarget.All , MonsterHealth);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(Pv.IsMine && collision.gameObject.tag == "Bullet")
        {
            MonsterHealth--;
            BossAni.SetTrigger("Take Damage");
            Pv.RPC("BossHealthStream" , RpcTarget.All , MonsterHealth);

        if(MonsterHealth <= 0)
        {
            BossAni.SetTrigger("Die");
            GameObject Explosion = PhotonNetwork.Instantiate("WFX_Nuke" , transform.position , Quaternion.identity , 0 ) as GameObject;
            Pv.RPC("BossDead" , RpcTarget.All);
        }

        }
    }

    [PunRPC]
    public void BossHealthStream(int Health)
    {   
        MonsterHealth = Health;
        TextHealth = GameObject.Find("BossHealthText").GetComponent<Text>();
        TextHealth.text = "Boss血量： " +Health.ToString();
    }

    [PunRPC]
    public void BossDead()
    {   
        PhotonNetwork.LeaveRoom();
        Destroy(gameObject,1f);
    }

}
