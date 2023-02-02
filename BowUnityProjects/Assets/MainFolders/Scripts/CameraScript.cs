using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    [SerializeField] private Transform _player;
    private float horizontal;
    private float vertical;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        UpdateRotation();
    }
    void UpdateRotation()
    {
        vertical = -Input.GetAxis("Mouse Y") * _sensivity * Time.deltaTime;
        horizontal = Input.GetAxis("Mouse X") * _sensivity * Time.deltaTime;
        _player.Rotate(0, horizontal, 0);
        transform.Rotate(vertical, 0, 0);
    }
}

