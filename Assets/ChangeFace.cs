using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MonoBehaviour
{
    GameObject body;
    public GameObject cam;
    public GameObject tempCam;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.transform.GetChild(1).transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") return;
        Material targetMaterial = other.GetComponent<Renderer>().material;
        body.GetComponent<Renderer>().material.mainTexture = targetMaterial.mainTexture;

        if (!flag)
        {
            flag = true;
            cam.SetActive(false);
            tempCam.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(controlCamera());
        }
    }
    IEnumerator controlCamera()
    {
        yield return new WaitForSeconds(1f);
        tempCam.SetActive(false);
        cam.SetActive(true);
    }
}
