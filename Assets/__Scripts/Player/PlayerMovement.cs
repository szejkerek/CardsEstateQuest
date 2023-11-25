using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player movement and interaction.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject playerCamera;

    private float horizontalInput;
    private float verticalInput;
    GridManager gridManager;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gridManager = FindObjectOfType<GridManager>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        ClampPosition();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (playerCamera.gameObject.activeSelf)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void ClampPosition()
    {
        if (playerCamera.gameObject.activeSelf)
        {
            Vector3 minBoundary = gridManager.GetMinBoundary();
            Vector3 maxBoundary = gridManager.GetMaxBoundary();

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBoundary.x, maxBoundary.x);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBoundary.z, maxBoundary.z);
            transform.position = clampedPosition;
        }
    }

    private void SpeedControl()
    {
        if (playerCamera.gameObject.activeSelf)
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
            else if (flatVel.magnitude > 0)
            {
                float friction = 7f;
                rb.AddForce(-flatVel.normalized * friction, ForceMode.Force);
            }
        }
    }
}
