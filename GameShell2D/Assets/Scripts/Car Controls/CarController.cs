﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour
{
    InputController controls;
    private Vector2 leftStick;
    private float rightTrigger;
    private float leftTrigger;

    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, groundRayLength = 0.5f;

    //private float speedInput, turnInput;

    private float forwardGas, backwardGas, turnInput;

    public LayerMask whatIsGround;
    //public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    private bool grounded;


    private void Awake()
    {
        controls = new InputController();

        controls.Gameplay.AButton.started += ctx => WhyS();
        controls.Gameplay.AButton.performed += ctx => WhyP();
        controls.Gameplay.AButton.canceled += ctx => WhyC();

        controls.Gameplay.LeftStick.performed += ctx => leftStick = ctx.ReadValue<Vector2>();
        controls.Gameplay.LeftStick.canceled += ctx => leftStick = Vector2.zero;

        controls.Gameplay.RightTrigger.performed += ctx => rightTrigger = ctx.ReadValue<float>();
        controls.Gameplay.RightTrigger.canceled += ctx => rightTrigger = 0f;
        
        controls.Gameplay.LeftTrigger.performed += ctx => leftTrigger = ctx.ReadValue<float>();
        controls.Gameplay.LeftTrigger.canceled += ctx => leftTrigger = 0f;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void WhyS()
    {
        print("started");
    }

    void WhyP()
    {
        print("performed");
    }

    void WhyC()
    {
        print("cancelled");
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = theRB.transform.position;
        //print("left Stick" +  leftStick);
        turnInput = leftStick.x;
        forwardGas = rightTrigger;
        backwardGas = leftTrigger;

        //print("right trigger " + rightTrigger);
        //print("left trigger " + leftTrigger);

        //print("turnInput " + turnInput);


        /*
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }

        transform.position = theRB.transform.position;*/

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * forwardGas * Time.deltaTime, 0f));
        transform.position = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;
        }

        if (grounded)
        {
            theRB.AddForce(transform.forward * forwardGas * forwardAccel * 1000f);
        }
        //print(leftStick);
        /*
        if(Mathf.Abs(speedInput) > 0)
        {
            theRB.AddForce(transform.forward * speedInput);
        }
        //theRB.AddForce(transform.forward * forwardAccel * 1000f);
        */

        

    }




}
