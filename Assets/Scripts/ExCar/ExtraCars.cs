using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCars : MonoBehaviour
{
    Transform tr;   
    Rigidbody rb;

    float moveSpeed = 17;
    Vector3 direction = new Vector3(0, 0, 1);

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        tr.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.tr.tag == "FwCar" && collision.transform.tag == "RvCar")
        {
            moveSpeed = 0;
        }
        else if (this.tr.tag == "RvCar" && collision.transform.tag == "FwCar")
        {
            moveSpeed = 0;
        }
        else if (collision.transform.tag == "Player")
        {
            moveSpeed = 0;
        }
    }
}