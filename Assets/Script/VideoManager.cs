using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject Screen;
    public GameObject Character;
    public GameObject spotLight;
    public GameObject plane;
    public GameObject cam;
    public GameObject FallDownCamera;
    public float distance = 3f;
    bool isDestroyed = false;
    void Start()
    {
        videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDestroyed) return;
        if (videoPlayer.frame == (long)videoPlayer.frameCount - 3) // HCAK
        {
            cam.SetActive(true);
        }
        if (videoPlayer.frame == (long)videoPlayer.frameCount-1) // HACK: -1
        {
            Destroy(videoPlayer);
            Destroy(Screen);
            isDestroyed = true;
            Character.SetActive(true);
            spotLight.SetActive(true);
            plane.SetActive(true);
            FallDownCamera.SetActive(false);
            RenderSettings.fog = true;

            spotLight.transform.position = cam.transform.position + distance * cam.transform.forward;
            spotLight.transform.position = new Vector3(spotLight.transform.position.x, 5.1f, spotLight.transform.position.z);
            spotLight.transform.eulerAngles = new Vector3(spotLight.transform.eulerAngles.x, cam.transform.eulerAngles.y, spotLight.transform.eulerAngles.z);
        }
    }
}
