using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offSet = new Vector3(0, 5, -7);
    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
