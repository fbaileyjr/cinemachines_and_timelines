using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] _virtualCameras;

    private int _arrayLength;
    private int _cameraCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_virtualCameras == null)
        {
            Debug.Log("No camera objects were selected!");
        }

        _arrayLength = _virtualCameras.Length;
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
            _cameraCount += 1;
            for (int count = 0; count < _arrayLength; count++)
            {
                if (_cameraCount == (_arrayLength))
                {
                    _cameraCount = 0;
                }

                if (count != _cameraCount)
                {
                    _virtualCameras[count].SetActive(false);
                }
                else
                {
                    _virtualCameras[count].SetActive(true);
                }
            }


        }
    }
}
