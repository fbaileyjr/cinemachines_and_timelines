using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera[] _virtualCameras;

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
        
    }

    private void _updateCameraPriority()
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
                _virtualCameras[count].m_Priority = 100;
            }
            else
            {
                _virtualCameras[count].m_Priority = 150;
            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _updateCameraPriority();
    }

}
