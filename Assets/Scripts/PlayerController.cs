using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedoMeter;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    private float speed = 15f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] private float ForcePower;
    Rigidbody playerRb;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedoMeter.SetText("Speed : " + speed + "mph");
        CameraChange();
        GetInput();
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
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
