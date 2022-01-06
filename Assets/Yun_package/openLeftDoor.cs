using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openLeftDoor : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("open", true);
        StartCoroutine(LoadSceneCoroutine());
    }

    void OnTriggerExit(Collider other)
    {
        _animator.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }   
    }
}
