using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform car;

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = car.position;
        temp.z = -10;
        transform.position = temp;
    }
}
