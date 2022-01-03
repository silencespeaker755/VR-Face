using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class follower : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject Follower;
    public float FollowSpeed;
    public RaycastHit Shot;
    public GameObject MainCamera;
    public GameObject FallDownCamera;
    public GameObject MainCharacter;
    bool flag = false;
    PlayableDirector playableDirector;

    private void Start()
    {
        playableDirector = FallDownCamera.GetComponent<PlayableDirector>();
    }
    void FixedUpdate()
    {
        transform.LookAt(Player.transform);
        TargetDistance = Shot.distance;
        FollowSpeed = .015f; //0.015
        Vector3 target = Player.transform.position;
        target.y = 0;
        
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        
        if (dist <= 1.2 && !flag) 
        {
            flag = true;
            FallDownCamera.transform.position = MainCamera.transform.position;
            FallDownCamera.transform.rotation = MainCamera.transform.rotation;

            MainCamera.SetActive(false);
            MainCharacter.SetActive(false);
            
            FallDownCamera.SetActive(true);
            playableDirector.Play();
            StartCoroutine(LoadSceneCoroutine());

        }
        transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(1);
    }
}
