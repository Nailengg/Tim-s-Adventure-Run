using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    float maxX;

    void Start()
    {
        maxX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player.position.x > maxX)
        {
            maxX = player.position.x;
        }

        transform.position = new Vector3(
            maxX,
            transform.position.y,
            transform.position.z
        );
    }
}