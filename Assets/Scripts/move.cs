using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class move : MonoBehaviour
{
    //move
    
    private CharacterController characterController;
    [SerializeField] private float speed;
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {   
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move* Time.deltaTime*speed);

        AddGravity();
        ResetVelocity();
        FollowMouse();
        Jump();
    }

    


    //gravity
    [SerializeField] private float gravity = -9.81f;
    private Vector3 velocity;

   private void AddGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    // reset velocity
    [SerializeField] private Transform basePoint;
    [SerializeField] private float baseRadius = 0.4f;
    [SerializeField] private LayerMask layerMask;
    private bool isGrounded = false;

    private void ResetVelocity()
    {
        isGrounded = Physics.CheckSphere(basePoint.position, baseRadius, layerMask);
        if( isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
    }


    //1t person

    [SerializeField] private float mouseSensitivity;
    [SerializeField] private GameObject mainCamera;
    float xRotation = 0f;

    private void FollowMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        characterController.transform.Rotate(Vector3.up * mouseX);

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        //disable the earlier one
        characterController.Move(move * Time.deltaTime * speed);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
    
    //jump


    [SerializeField] private float jumpHeight = 3f;

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

    }

}
