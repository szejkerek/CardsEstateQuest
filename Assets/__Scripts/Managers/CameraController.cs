using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 _delta;
    private float _zoomDelta;

    private bool _isZooming;
    private bool _isMoving;
    private bool _isRotating;
    private bool _isBusy;

    private float _xRotation;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float zoomSpeed = 1f;


    private void Awake()
    {
        _xRotation = transform.rotation.eulerAngles.x;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (_isBusy) return;

        _isRotating = context.started || context.performed;

    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if (_isBusy) return;

        _zoomDelta = context.ReadValue<Vector2>().y/100;
        _isZooming = context.started || context.performed;

       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_isBusy) return;

        _isMoving = context.started || context.performed;


    }

    private void LateUpdate()
    {
        if (_isMoving)
        {
            var position = transform.right * (_delta.x * -movementSpeed);
            position += transform.up * (_delta.y * -movementSpeed);
            transform.position += position * Time.deltaTime;
        }
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
