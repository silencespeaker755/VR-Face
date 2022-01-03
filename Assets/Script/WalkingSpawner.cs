using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    int counter;
    public float checkRadius = 0.001f;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if (counter % 50 == 0)
        {
            //float xOffset = Random.Range(3, 10) * (Random.Range(0, 2) * 2 - 1);
            //float zOffset = Random.Range(0, 5);
            float xOffset = ((counter / 15) % 4) * 1.5f * (Random.Range(0, 2) * 2 - 1);
            float zOffset = 0;

            //Vector3 spawnPoint = transform.position + new Vector3(xOffset, 0, zOffset);
            Vector3 spawnPoint = transform.position;

            if (!Physics.CheckSphere(spawnPoint, checkRadius, 1 << 14))
            {
               objectPooler.SpawnFromPool("Walking", spawnPoint, Quaternion.identity);
            }

            //float xOffset2 = Random.Range(3, 10) * (Random.Range(0, 2) * 2 - 1);
            //float zOffset2 = Random.Range(0, 5);
            //float xOffset2 = ((counter / 20) + 2) % 10;
            //float zOffset2 = 0;
           // Vector3 spawnPoint2 = transform.position + new Vector3(xOffset2, 0, zOffset2);

            //if (!Physics.CheckSphere(spawnPoint2, checkRadius, 1 << 14))
            {
                //objectPooler.SpawnFromPool("TextingAndWalking", spawnPoint2, Quaternion.identity);
            }

        }
        
        counter++;
    }
}
