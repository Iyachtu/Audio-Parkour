using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Vector2 _mouseSensitivity, _padSensitivity, _mouseYLimit;
    private float _horizontal, _vertical;
    [SerializeField] private Transform _cameraTransform;

    private void Awake()
    {
        Cursor.lockState= CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);

        //rotation joueur
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + _horizontal, transform.eulerAngles.z);

        //rotation caméra
        _cameraTransform.eulerAngles = new Vector3(_cameraTransform.eulerAngles.x+ _vertical,_cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);
    }

    private void GetInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity.y * Time.deltaTime;
        // gamePadX = Input.GetAxis("RightHorizontal") * _padSensitivity.x * Time.deltaTime;
        float gamePadX = 0;
        //float gamePadY = Input.GetAxis("RightVertical") * _padSensitivity.y * Time.deltaTime;
        float gamePadY = 0;
        _horizontal= mouseX - gamePadX;
        _vertical= mouseY - gamePadY;
    }


}
