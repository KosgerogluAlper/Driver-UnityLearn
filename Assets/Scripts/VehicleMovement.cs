using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    private float vehicleSpeed = 15f;

    private void Update()
    {
        transform.Translate(Vector3.forward * vehicleSpeed * Time.deltaTime);
    }
}
