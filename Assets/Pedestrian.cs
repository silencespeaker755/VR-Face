using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public float speed = 1.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= Vector3.forward * Time.deltaTime * speed;
    }
}
