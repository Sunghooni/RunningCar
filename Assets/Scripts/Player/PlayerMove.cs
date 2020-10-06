using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //Setting
    Transform tr;
    Rigidbody rb;
    public float speed = 25;
    public float rotSpeed = 0;
    Vector3 moveDir;
    //Input
    float hz = 0;
    float vt = 0;
    //PlayerInfo
    float playerX;
    float playerY;
    float playerZ;
    //Ray
    RaycastHit hit;
    Vector3 midRayPoint;
    Vector3 rtRayPoint;
    Vector3 ltRayPoint;

    public bool canRot = true;
    public Text restart;
    public GameObject tutorial;
    Tutorial tuto;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        moveDir = new Vector3(0, 0, 1);
        tuto = tutorial.GetComponent<Tutorial>();
    }
    void Update()
    {
        playerX = this.tr.position.x;
        playerY = this.tr.position.y;
        playerZ = this.tr.position.z;
        //RayPosition
        midRayPoint = new Vector3(playerX, playerY + 0.5f, playerZ);
        rtRayPoint = new Vector3(playerX + 0.4f, playerY + 0.5f, playerZ);
        ltRayPoint = new Vector3(playerX - 0.4f, playerY + 0.5f, playerZ);
        //Input
        hz = Input.GetAxis("Horizontal");
        vt = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        tr.Translate(moveDir * speed * Time.deltaTime);
        rb.AddForce(new Vector3(0, -20, 0) , ForceMode.Force);
        if (hz != 0 && canRot)
        {
            rotSpeed = hz * (speed - 5);
            tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        if(vt != 0)
        {
            if (speed > 35)
                speed = 35;
            else if (speed < 25)
                speed = 25;
            else
                speed += vt/2;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 전방에 3개의 ray를 쏴서 충돌 지점이 정면일 경우에만 stop
        if (Physics.Raycast(midRayPoint, transform.forward, out hit, 3.8f))
        {
            if (hit.transform.name != "PlayerCar")
            {
                speed = 0;
                moveDir = Vector3.zero;
                canRot = false;
                restart.text = "Press R to Restart";
                tuto.doTimer = false;
            }
        }
        else if(Physics.Raycast(rtRayPoint, transform.forward, out hit, 3.8f))
        {
            if (hit.transform.name != "PlayerCar")
            {
                speed = 0;
                moveDir = Vector3.zero;
                canRot = false;
                restart.text = "Press R to Restart";
                tuto.doTimer = false;
            }
        }
        else if (Physics.Raycast(ltRayPoint, transform.forward, out hit, 3.8f))
        {
            if (hit.transform.name != "PlayerCar")
            {
                speed = 0;
                moveDir = Vector3.zero;
                canRot = false;
                restart.text = "Press R to Restart";
                tuto.doTimer = false;
            }
        }

        if(collision.transform.name == "End")
        {
            if(tuto.timerCnt <= 25)
            {
                restart.text = "Clear! Press R to Restart";
                moveDir = Vector3.zero;
                tuto.doTimer = false;
            }
            else
            {
                restart.text = "Failed! Press R to Restart";
                moveDir = Vector3.zero;
                tuto.doTimer = false;
                canRot = false;
            }
        }
    }
}