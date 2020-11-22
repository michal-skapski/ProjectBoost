using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Transform _launchPadPos;
    private AudioSource _audioSource;
    private Rigidbody _rb;
    private int _zeroVal = 0;
    private int _threeVal = 3;
    [SerializeField] private float _rcsThrust = 100f;
    private float _rotationThisFrame;
    private int _xLauchPadPos = -17;
    private enum State{ Alive, Dying, Transcending};
    private State _state = State.Alive;
    private string _loadStartSceneMethod = "LoadStartScene", _loadNextSceneMethod = "LoadNextScene";
    private float _loadNextSceneTime=1f, _loadStartSceneTime = 0.5f;
    /*
    private void ResetPosition()
    {
        _rb.freezeRotation = true;
        transform.position = new Vector3(_xLauchPadPos, _threeVal, _zeroVal);
        transform.rotation = Quaternion.identity;
        _audioSource.Stop();
        _rb.freezeRotation = false;
    }
    */
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
        _rotationThisFrame = _rcsThrust * Time.deltaTime;
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

    private void OnCollisionEnter(Collision collision) // this is calling when another objects collider / rigidbody will touch another object
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly": Debug.Log("OK"); break; // to do 
            case "FinishLine":
                Invoke(_loadNextSceneMethod, _loadNextSceneTime);
                _state = State.Transcending;
            break; 
            case "FuelPlus": Debug.Log("Fueld up"); break; // extra to do 
            default:
                _state = State.Dying;
                Invoke(_loadStartSceneMethod,_loadStartSceneTime);
                break; // to do kill the player (maybe use the reset position function)
        }
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)||Input.GetKeyDown(KeyCode.Keypad0))
        {
           // ResetPosition();
        }
        if(_state != State.Dying)
        {
            Thrust();
            Rotate();
        }
    }
}




/*
private void OnTriggerEnter(Collider other) // this is gona make when you enter something with a trigger in the collider component 
{
    Debug.Log("A trigger had been detected");
}
*/