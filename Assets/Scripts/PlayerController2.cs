using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private TextMeshProUGUI speedoMeter;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] private float ForcePower;
    Rigidbody playerRb;
    private float speed;


    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }



    void Update()
    {

        GetInput();
        CameraChange();
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedoMeter.SetText("Speed : " + speed + "mph");
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");
    }

    private void Move()
    {
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * ForcePower);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    private void CameraChange()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }


    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}




