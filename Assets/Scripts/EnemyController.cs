using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    PhotonView Pv;
    public NavMeshAgent agent;
    public GameObject TargetPlayer;
    public Animator EnemyAni;


    void Start()
    {
        Pv = GetComponent<PhotonView>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        EnemyAni.SetBool("Run", true);
    }

    void Update()
    {
        TargetPlayer = GameObject.FindWithTag("Player");
        agent.SetDestination(TargetPlayer.transform.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (Pv.IsMine && collision.gameObject.tag == "Bullet")
        {
            EnemyAni.SetBool("Run", false);
            EnemyAni.SetTrigger("Die");
            GameObject Explosion = PhotonNetwork.Instantiate("Explosion", transform.position, Quaternion.identity, 0) as GameObject;
            Pv.RPC("EnemyDead", RpcTarget.All);
        }
    }



    [PunRPC]
    public void EnemyDead()
    {
        Destroy(gameObject, 2f);
    }


}
