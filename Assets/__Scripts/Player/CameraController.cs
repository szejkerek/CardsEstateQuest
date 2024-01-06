using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementTime;

    [SerializeField] private Vector3 newPosition;
    [SerializeField] private Quaternion newRotation;
    [SerializeField] private Vector3 newZoom;

    [SerializeField] private float rotationAmount;
    [SerializeField] private Vector3 zoomAmount;

    private void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;    
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
    }
   
    void HandleMovementInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) )
            {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
       
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
