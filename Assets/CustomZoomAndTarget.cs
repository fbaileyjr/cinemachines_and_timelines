using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CustomZoomAndTarget : MonoBehaviour
{
    [SerializeField]
    GameObject[] _targets;

    CinemachineVirtualCamera _cvCamera;

    private int _cameraCount = 0;
    private int _focus = 60;

    // Start is called before the first frame update
    void Start()
    {
        _cvCamera = this.transform.GetComponent<CinemachineVirtualCamera>();

        if (_targets == null)
        {
            Debug.Log("Gameobjects on CustomZoom are null!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        keyInput();
    }

    private void keyInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_cameraCount == 0)
            {
                _cameraCount = 1;
            }
            else
            {
                _cameraCount = 0;
            }

            _cvCamera.LookAt = _targets[_cameraCount].transform;

            Debug.Log("Current target is " + _cameraCount);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _cvCamera.m_Lens.FieldOfView = _focus;
            _focus -= 20;
            if (_focus == 0)
            {
                _focus = 60;
            }

        }
    }
}
