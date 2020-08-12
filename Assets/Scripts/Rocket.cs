using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rb;
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            
        }
    }

    private void Awake()
    {
        _rb = _rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessInput();
    }
}
