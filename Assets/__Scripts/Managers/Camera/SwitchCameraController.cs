using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private int _manager;

    public void ManageCamera()
    {
        if(_manager == 0)
        {
            PlayerCamera();
            _manager = 1;
        }
       else
        {
            MainCamera();
            _manager = 0;
        }
    }
    void PlayerCamera()
    {
        _mainCamera.SetActive(true);
        _playerCamera.SetActive(false);
    }

    void MainCamera()
    {
        _mainCamera.SetActive(false);
        _playerCamera.SetActive(true);
    }    
}
