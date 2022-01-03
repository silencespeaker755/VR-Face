using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject rig;
    float xOffset;
    float zOffset;
    public float FollowSpeed;

    public void Start()
    {
        xOffset = Random.Range(0, 10) * (Random.Range(0, 2) * 2 - 1);
        zOffset = Random.Range(0, 8) * (Random.Range(0, 2) * 2 - 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = rig.transform.position;
        target.x += xOffset;
        target.z += zOffset;
        target.y = 0;

        transform.LookAt(rig.transform);
        FollowSpeed = .02f;

        transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);

    }
}
