using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mousesensi = 100.0f;

    public Transform player;

    private float xRotate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensi * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotate, 0.0f, 0.0f);
        player.Rotate(Vector3.up * mouseX);
    }

}
