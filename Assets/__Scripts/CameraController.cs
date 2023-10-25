using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class responsible for controlling the camera's movement and zoom using input actions.
/// </summary>
public class CameraController : MonoBehaviour
{
    private Vector2 _delta;
    private float _zoomDelta;

    private bool _isZooming;
    private bool _isRotating;
    private bool _isBusy;

    private float _xRotation;

    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float zoomSpeed = 1f;

    private void Awake()
    {
        _xRotation = transform.rotation.eulerAngles.x;
    }

    /// <summary>
    /// Callback for handling look input.
    /// </summary>
    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Callback for handling rotation input.
    /// </summary>
    public void OnRotate(InputAction.CallbackContext context)
    {
        if (_isBusy) return;
        _isRotating = context.started || context.performed;
    }

    /// <summary>
    /// Callback for handling zoom input.
    /// </summary>
    public void OnZoom(InputAction.CallbackContext context)
    {
        if (_isBusy) return;
        _zoomDelta = context.ReadValue<Vector2>().y / 100;
        _isZooming = context.started || context.performed;
    }

    private void LateUpdate()
    {
        if (_isRotating)
        {
            transform.Rotate(new Vector3(_xRotation, -_delta.x * rotationSpeed, 0.0f));
            transform.rotation = Quaternion.Euler(_xRotation, transform.rotation.eulerAngles.y, 0.0f);
        }
        if (_isZooming)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - _zoomDelta, 1f, 30f);
        }
    }
}
