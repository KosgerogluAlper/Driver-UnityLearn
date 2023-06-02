using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCamera : MonoBehaviour
{
    Vector3 offSet = new Vector3(0f, 2f, 2.5f);
    [SerializeField] private GameObject player;
    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }

}
