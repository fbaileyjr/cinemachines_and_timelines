using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class custom_3rd_person : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] GameObject _thirdCamera;
    [SerializeField] GameObject _orbCamera;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        if(_thirdCamera == null)
        {
            Debug.LogWarning("Missing _thirdCamera.");
        }
        if (_orbCamera == null)
        {
            Debug.LogWarning("Missing _orbCamera.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            switchCameraIfMouseDown();
        } else
        {
            switchCameraIfMouseUp();
        }

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        _direction = new Vector3(0, 0, _vertical);
        _direction *= _moveSpeed * Time.deltaTime;
        _controller.Move(_direction);

        Vector3 rotation = new Vector3(0, _horizontal * _rotateSpeed * Time.deltaTime, 0);
        this.transform.Rotate(rotation);
    }

    void switchCameraIfMouseDown()
    {
        _thirdCamera.SetActive(false);
        _orbCamera.SetActive(true);

    }

    void switchCameraIfMouseUp()
    {
        _thirdCamera.SetActive(true);
        _orbCamera.SetActive(false);

    }
}
