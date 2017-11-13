using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;

    public Vector3 offset;
    public float speed;


    void Start()
    {

    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + offset, speed);
    }
}
