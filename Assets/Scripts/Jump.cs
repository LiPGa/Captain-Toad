using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float verticalVelocity = 0; 
    public float gravity;
    public float speed;
    public float jumpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update() { 
        CharacterController controller = GetComponent<CharacterController>(); 
        if (controller.isGrounded) { 
            if (Input.GetButton ("Jump")) { 
                verticalVelocity = jumpSpeed; 
            } 
            else { 
                verticalVelocity = 0; 
            } 
        } 
        else 
        { 
            verticalVelocity -= gravity * Time.deltaTime; 
        } 

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, verticalVelocity, Input.GetAxis("Vertical") * speed); 
        moveDirection = transform.TransformDirection(moveDirection); 
        controller.Move(moveDirection * Time.deltaTime); 
    } 
}

