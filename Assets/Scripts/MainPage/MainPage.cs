using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public GameObject Player;
    public GameObject RvCar;
    public GameObject FwCar;
    public GameObject Canvas;
    public GameObject startCanvas;
    public GameObject startCamera;

    void Start()
    {
        Player.SetActive(false);
        RvCar.SetActive(false);
        FwCar.SetActive(false);
        Canvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            startCamera.SetActive(false);
            Player.SetActive(true);
            RvCar.SetActive(true);
            FwCar.SetActive(true);
            Canvas.SetActive(true);
            startCanvas.SetActive(false);
        }
    }
}
