using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rb;
    private int _zeroVal = 0;
    private int _threeVal = 3;
    [SerializeField] private float _rotationforce = 100f;
    private float _rotationThisFrame;

    private void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _rb.freezeRotation = true;
            transform.position = new Vector3(_zeroVal, _threeVal, _zeroVal);
            transform.rotation = Quaternion.identity;
            _audioSource.Stop();
            _rb.freezeRotation = false;
        }
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                _audioSource.Play();
            }
            _rb.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _audioSource.Stop();
        }
    }
    private void Rotate()
    {
        _rotationThisFrame = _rotationforce * Time.deltaTime;
        _rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                _audioSource.Play();
            }
            transform.Rotate(Vector3.forward*_rotationThisFrame);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!_audioSource.isPlaying) // so it does not layer
            {
                _audioSource.Play();
            }
            transform.Rotate(-Vector3.forward * _rotationThisFrame);
        }        
        else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            _audioSource.Stop();
        }
        _rb.freezeRotation = false;
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
        Rotate();
    }
}
