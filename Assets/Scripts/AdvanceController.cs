using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AdvanceController : BasicController
{
    CharacterController characterController;
    public float gravity;
    private float verticalVelocity = 0.0f;
    private Vector2 dir;
    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        Vector2 inputValue = ReadInput();

        Vector3 moveDir = GetMoveDirInWorldSpace(inputValue);

        Vector3 move = CalculateMove(moveDir);        

        characterController.Move(move);

        UpdateDirection(moveDir);

        if (move.magnitude > 0.01f)
        {
            inMove = true;
        }
        else
        {
            inMove = false;
        }
    }

    private void Update()
    {
        
    }

    Vector3 CalculateMove(Vector3 moveDir)
    {
        CharacterController controller = GetComponent<CharacterController>(); 
        Vector3 move = Vector3.zero;
        if (controller.isGrounded){
            move = moveDir * speed * Time.fixedDeltaTime;
        }
        // Vector3 move = moveDir * speed * Time.fixedDeltaTime;
        ApplyGravity(ref move);
        return move;
    }

    void ApplyGravity(ref Vector3 move)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = 0.0f;
        }
        else
        {
            verticalVelocity -= gravity * Time.fixedDeltaTime;
        }

        move += Vector3.up * verticalVelocity * Time.fixedDeltaTime;
    }

    void UpdateDirection(Vector3 moveDirection)
    {
        if (moveDirection.magnitude > 0.01f)
            transform.forward = moveDirection;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
            body.velocity = characterController.velocity;
    }

}
