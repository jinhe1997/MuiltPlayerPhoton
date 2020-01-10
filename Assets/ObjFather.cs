using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFather : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FatherOBJ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player(Clone)"))
        {
            FatherOBJ = GameObject.Find("Player(Clone)").transform;
            transform.parent = FatherOBJ;
        }

    }
}
