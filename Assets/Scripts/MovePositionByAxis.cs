using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float jumpPower = 200f;

    [SerializeField]
    private Rigidbody physicsBody;




    private void OnDestroy() 
    {
        InputManager.Instance.UnRegisterOnJumpInput(Jump);
    }
    // Update is called once per frame
    private void Start()
    {
        InputManager.Instance.RegisterOnJumpInput(Jump);
    }
    void Update()
    {
       // Vector3 NewVelocity = InputManager.Instance.movementInput * speed;
        NewVelocity.y = physicsBody.velocity.y;
        physicsBody.velocity = NewVelocity;
    }
    private void Jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up * jumpPower);
    }
}