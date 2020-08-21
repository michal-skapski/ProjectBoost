using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rb;
    private int _zeroVal = 0;
    private int _threeVal = 3;

    private void AudioPlay()
    {
        _audioSource.Play();
    }
    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = new Vector3(_zeroVal, _threeVal, _zeroVal);
            transform.rotation = Quaternion.identity;
            _audioSource.Stop();
        }
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                AudioPlay();
            }
            _rb.AddRelativeForce(Vector3.up);
        }
    }
    private void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                AudioPlay();
            }
            transform.Rotate(Vector3.forward);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                AudioPlay();
            }
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
        Thrust();
        Rotation();
    }
}
