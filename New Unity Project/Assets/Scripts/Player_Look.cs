using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Look : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public Transform playerBody;
    float rotation_X = 0f;

    void Start()
    {
        // Hide and Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotation_X -= mouseY;
        rotation_X = Mathf.Clamp(rotation_X, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation_X, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
