using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float walkSpeed = 5f;
    public MainCameraController MCamController;


    private void Update()
    {
        PlayerMovement();
    }

    void    PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(x) + Mathf.Abs(z);
        Vector3 move = new Vector3(x, 0, z).normalized;
        Vector3 direction = MCamController.flatRotation * move;

        if (moveAmount >= 0.1f)
        {
            transform.position += move * walkSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        transform.position += move * walkSpeed * Time.deltaTime;
    }
}
