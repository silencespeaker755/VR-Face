using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    CharacterController characterController;
    public GameObject rig;
    //Vector3 offset = new Vector3(Random.Range(5, 10), 0, 0);
    Vector3 difference;

    float xOffset;
    float zOffset;


    public float FollowSpeed;

    public void Start()
    {
        difference = rig.transform.position - transform.position;

        xOffset = Random.Range(5, 10) * (Random.Range(0, 2) * 2 - 1);
        zOffset = Random.Range(0, 8) * (Random.Range(0, 2) * 2 - 1);
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        difference.y = 0;
        difference.Normalize();
        //characterController.Move(difference * Time.deltaTime);


        transform.LookAt(rig.transform);
        FollowSpeed = .02f;
        Vector3 target = rig.transform.position;
        
        target.y = 0;
        //target.x += xOffset;
        //target.z += zOffset;

        transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);

    }
}
