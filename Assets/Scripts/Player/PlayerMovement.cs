using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using MoveInputActions;


public class PlayerMovement:MonoBehaviour
{
    [SerializeField, Header("Config")] private float speed;
    private @Movement2 actions;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    private Animator moving;


    private void Awake()
    {
        actions = new @Movement2();
        rigidBody = GetComponent<Rigidbody2D>();
        moving = GetComponent<Animator>();

        Debug.Log(actions.Movement.Move.bindings.Count);
        Debug.Log(rigidBody);
    }





    // ENABLE AND DISABLE

    private void OnEnable()
    {
        actions.Enable();
    }
 

    private void OnDisable()
    {
        actions.Disable();
    }





    // PLAYER MOVEMENT

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        moving.SetBool("IsMoving", false);

        if (moveDirection == Vector2.zero)
        {
            return;
        }

        moving.SetBool("IsMoving", true);

        moving.SetFloat("MoveX", moveDirection.x);
        moving.SetFloat("MoveY", moveDirection.y);
    }


    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * (speed * Time.fixedDeltaTime));
    }


    private void FixedUpdate()
    {
        Move();
    }


    private void Update()
    {
        ReadMovement();
    }
}
