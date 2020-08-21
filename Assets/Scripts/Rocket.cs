using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rb;
    private int _zeroVal = 0;
    private int _threeVal = 3;

    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = new Vector3(_zeroVal, _threeVal, _zeroVal);
            transform.rotation = Quaternion.identity;
        }
    }
    private void ProcessInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(Vector3.up);  
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ResetPosition();
        ProcessInput();
    }
}
