using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;


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
    public Camera cam;
    bool start = false;
    bool flag = false;
    PlayableDirector playableDirector;
    public XRBaseController LeftHand;
    public XRBaseController RightHand;


    void ActivateHaptic()
    {
        RightHand.SendHapticImpulse(1f, 1.5f);
        LeftHand.SendHapticImpulse(1f, 1.5f);
    }
    private void Start()
    {
        playableDirector = FallDownCamera.GetComponent<PlayableDirector>();
    }
    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0) return false;
        }
        return true;
    }
    private void Update()
    {
        if (IsVisible(cam, gameObject))
        {
            start = true;
        }
    }
    void FixedUpdate()
    {
        if (start)
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
                //FallDownCamera.transform.rotation = MainCamera.transform.rotation;
                FallDownCamera.transform.eulerAngles = MainCamera.transform.eulerAngles;
                //FallDownCamera.transform.eulerAngles = new Vector3(MainCamera.transform.eulerAngles.x, MainCamera.transform.eulerAngles.y - 180, MainCamera.transform.eulerAngles.z);

                MainCamera.SetActive(false);
                MainCharacter.SetActive(false);

                FallDownCamera.SetActive(true);
                playableDirector.Play();
                StartCoroutine(LoadSceneCoroutine());
                ActivateHaptic();
            }
            transform.position = Vector3.MoveTowards(transform.position, target, FollowSpeed);
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(2);
    }
}
