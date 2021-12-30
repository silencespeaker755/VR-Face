using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class follower : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject Follower;
    public float FollowSpeed;
    public RaycastHit Shot;

    void Update()
    {
        transform.LookAt(Player.transform);
        TargetDistance = Shot.distance;
        FollowSpeed = .015f;
        Vector3 target = Player.transform.position;
        target.y = 0;

        float dist = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.Log(dist);
        if (dist <= 4) 
        {
            SceneManager.LoadScene(1);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);
    }
}
