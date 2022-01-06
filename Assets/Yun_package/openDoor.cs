using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
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
    }

    void OnTriggerExit(Collider other)
    {
        _animator.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
