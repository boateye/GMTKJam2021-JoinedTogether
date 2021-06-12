using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour
{
    InputController controls;
    private Vector2 leftStick;

    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f;

    private float speedInput, turnInput;



    private void Awake()
    {
        controls = new InputController();

        controls.Gameplay.AButton.started += ctx => WhyS();
        controls.Gameplay.AButton.started += ctx => WhyP();
        controls.Gameplay.AButton.started += ctx => WhyC();

        controls.Gameplay.LeftStick.performed += ctx => leftStick = ctx.ReadValue<Vector2>();
        controls.Gameplay.LeftStick.canceled += ctx => leftStick = Vector2.zero;
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
        print("left Stick" +  leftStick);
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
    }

    private void FixedUpdate()
    {

        //print(leftStick);/*
        if(Mathf.Abs(speedInput) > 0)
        {
            theRB.AddForce(transform.forward * speedInput);
        }
        //theRB.AddForce(transform.forward * forwardAccel * 1000f);
        */
    }


}
