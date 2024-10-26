using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [Header("Camera Controller Settings")]
    [SerializeField] private Transform target;
    public float gapFromTarget = 2f;
    public float rotationSpeed = 1f;

    [Header("Camera Handler Settings")]
    public float minVerticalAngle = -15;
    public float maxVerticalAngle = 45f;
    public Vector2 framingBalance;
    float xRotation = 0f;
    float yRotation = 0f;
    public bool invertY = false;
    public bool invertX = false;
    float invertXValue;
    float invertYValue;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXValue = invertX ? -1 : 1;
        invertYValue = invertY ? -1 : 1;

        xRotation += Input.GetAxis("Mouse Y") * rotationSpeed * invertYValue;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);
        yRotation += Input.GetAxis("Mouse X") * rotationSpeed * invertXValue;

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Vector3 focusPosition = target.position + new Vector3(framingBalance.x, framingBalance.y, 0);

        transform.position = focusPosition - rotation * new Vector3(0, 0, gapFromTarget);
        transform.rotation = rotation;
    }

    public Quaternion flatRotation => Quaternion.Euler(0, yRotation, 0);
}
