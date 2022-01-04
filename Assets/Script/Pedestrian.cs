using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public float speed = 1f;
    public GameObject door;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position -= Vector3.forward * Time.deltaTime * speed;
        Vector3 target = door.transform.position;
        target.x -= 5;
        target.y = 0;

        transform.LookAt(door.transform);
        float FollowSpeed = .02f;

        transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);
    }
}
