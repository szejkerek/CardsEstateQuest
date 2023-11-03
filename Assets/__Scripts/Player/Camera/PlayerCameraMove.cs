using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the player camera to a specified position.
/// </summary>
public class PlayerCameraMove : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
