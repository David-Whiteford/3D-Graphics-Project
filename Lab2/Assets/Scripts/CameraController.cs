using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //set the initial position of camera
        offset = gameObject.transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //set updated position
        gameObject.transform.position = player.transform.position + offset;
    }
}
