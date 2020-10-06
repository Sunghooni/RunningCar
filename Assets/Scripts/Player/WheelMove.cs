using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    Transform tr;
    public GameObject player;

    public float rotSpeed = 0;
    float hz;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        hz = Input.GetAxis("Horizontal");

        rotSpeed = hz * 30;
        transform.localRotation = Quaternion.Euler(0, rotSpeed, 0);
            
        if (Input.GetKeyDown(KeyCode.S))
            this.transform.eulerAngles = new Vector3(0,0,0);
    }
}