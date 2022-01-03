using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject Character;
    public GameObject spotLight;
    bool isDestroyed = false;
    void Start()
    {
        videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDestroyed) return;
        if (videoPlayer.frame == (long)videoPlayer.frameCount-1) // HACK: -1
        {
            Destroy(videoPlayer);
            isDestroyed = true;
            Character.SetActive(true);
            spotLight.SetActive(true);
        }
    }
}
