using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    PhotonView pv;
    public GameObject Bullet;
    public Animator PlayerAni;
    public Text ManaText;
    public int Mana;

    public int force = 30;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        ManaText = GameObject.Find("ManaText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pv.IsMine && Input.GetKeyDown(KeyCode.Space) &&Mana >1)
        {
            pv.RPC("ShootBullet", RpcTarget.All, transform.Find("ShootPosition").transform.position, transform.Find("ShootPosition").transform.rotation);
            PlayerAni.SetTrigger("Attack");
            Mana --;
        }

        ManaText.text = Mana.ToString();

    }

    void OnCollisionEnter(Collision Col)
    {
        if (pv.IsMine && Col.gameObject.tag == "Managem")
        {
            Mana++;
        }
    }

    [PunRPC]
    void ShootBullet(Vector3 Pos, Quaternion Quaat)
    {
        GameObject Go = PhotonNetwork.Instantiate("Bullet", Pos, Quaat) as GameObject;

        Go.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
    }


}
