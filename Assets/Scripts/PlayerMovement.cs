using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _sprintSpeed;
    private CharacterController _characterController;
    private Vector3 _move;
    [SerializeField] AudioSource _footSteps;

    private void Awake()
    {
        _characterController= GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PlayerMove();
        FootStep();
    }

    private void PlayerMove()
    {
        _characterController.Move( _move );
    }

    private void GetInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right* horizontalInput +transform.forward *verticalInput;
        float _movespeed = 0;
        if (Input.GetButton("Fire3")) _movespeed = _sprintSpeed;
        else _movespeed = _speed;
        _move = direction * _movespeed * Time.deltaTime;
    }

    private void FootStep()
    {
        _footSteps.pitch = _characterController.velocity.magnitude / _speed;
    }
}
