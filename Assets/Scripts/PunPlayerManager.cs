using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
public class PunPlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView Pv;
    public Animator PlayerAni;
    public float Speed;
    
    public Transform PlayerBody;

    //  public GameObject PlayerCamera;

    //float xRotation = 0f;

    //public CharacterController controller;
    // public float mouseSensitivity = 100f;

    void Start()
    {
        // PlayerCamera  = GameObject.Find("Main Camera");

        Pv = photonView;

        //   CameraWork _cameraWork =
        //   this.gameObject.GetComponent<CameraWork>();
        //
        //   if (_cameraWork != null)
        //   {
        //       if (photonView.IsMine)
        //       {
        //           _cameraWork.OnStartFollowing();
        //       }
        //   }
        //   else
        //   {
        //       Debug.LogError("playerPrefab- CameraWork component 遺失",
        //           this);
        //   }

        //Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (Pv.IsMine)
        {
            // float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            // float z = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            // transform.position = transform.position + new Vector3(x, 0, z);

            //Vector3 move =transform.right * x + transform.forward * z;

            //  controller.Move(move * Speed * Time.deltaTime);

            //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //xRotation -= mouseY;

            //xRotation = Mathf.Clamp(xRotation , -90f , 90f);

            //transform.localRotation = Quaternion.Euler(xRotation , 0f , 0f);


            //  PlayerBody.Rotate(Vector3.up * mouseX);

            //  PlayerCamera.transform.rotation = PlayerBody.transform.rotation;

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * 20f * Time.deltaTime);
                PlayerAni.SetTrigger("Walk");
            }


            if (Input.GetKey(KeyCode.S))
                transform.Translate(-Vector3.forward * 20f * Time.deltaTime);


            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.left * 15f * Time.deltaTime);


            if (Input.GetKey(KeyCode.E))
                transform.Translate(Vector3.right * 15f * Time.deltaTime);


            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.up, -100f * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.up, 100f * Time.deltaTime);


        }
    }
}
