using System.Collections;
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
    public AudioSource carAudio;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, groundRayLength = 0.5f;
    public float downforce = 100f, gravityForce = 10f;
    public float drag = 3f,releaseDrag = 0f;
    public float enginePitch;
    private float calculatedDrag, forward;

    //private float speedInput, turnInput;

    private float forwardGas, brake, turnInput, speedInput;

    public LayerMask whatIsGround;
    //public float groundRayLength = 0.5f;
    public Transform groundRayPoint;

    private bool grounded;
    private Vector3 velocity, localVelocity;

    //public float rollLimit = 15f;


    private void Awake()
    {
        Physics.IgnoreLayerCollision(9,11);

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

    public Vector3 com = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;
        theRB.centerOfMass = com;
        theRB.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        carAudio.pitch = enginePitch;
        
        if (speedInput >= 0)
        {
            enginePitch = Mathf.Clamp(speedInput*2, 0.9f, 1.5f);
        }
        else if (speedInput < 0)
        {
            enginePitch = Mathf.Clamp(speedInput * -2, 0.9f, 1.1f);
        }

        theRB.centerOfMass = com;

        transform.position = theRB.transform.position;
        turnInput = leftStick.x;
        forwardGas = rightTrigger;
        brake = leftTrigger;

        velocity = theRB.velocity;
        localVelocity = transform.InverseTransformDirection(velocity);

        /*
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }

        transform.position = theRB.transform.position;
        */

        
        speedInput = forwardGas - brake;
        if(grounded && theRB.velocity.magnitude > 1f)
        {
            //print("moving");
            //if(speedInput > 0.15f) transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
            //if(speedInput < -0.15f) transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -turnInput * turnStrength * Time.deltaTime, 0f));
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, speedInput * turnInput * turnStrength * Time.deltaTime, 0f));
        }

        //transform.position = theRB.transform.position;

        //print("transform.rotation.z " + transform.rotation.eulerAngles.z);
        //transform.rotation= Quaternion.Euler(new Vector3(theAngle,0f,0f));
        //print(transform.rotation.eulerAngles.z + " " + zAngleLimit);

        float x = transform.rotation.eulerAngles.x;
        float y = transform.rotation.eulerAngles.y;
        float z = transform.rotation.eulerAngles.z;

        if (z > zAngleLimit && z < 181) transform.rotation = Quaternion.Euler(new Vector3(x, y, zAngleLimit));
        if (z < 360 - zAngleLimit && z > 271) transform.rotation = Quaternion.Euler(new Vector3(x, y, -zAngleLimit));

        //this limits front flips and backflips but it might not be necessary, since being upsidedown would automatically flip the vehicle back upward so it doesn't matter
        //DOES NOT WORK YET
        //if (transform.rotation.eulerAngles.x > xAngleLimit) transform.rotation = Quaternion.Euler(new Vector3(xAngleLimit, y, z));
        //if (transform.rotation.eulerAngles.x < -xAngleLimit) transform.rotation = Quaternion.Euler(new Vector3(-xAngleLimit, y, z));

        //calculate correct dampen
        //high dampen when slow, lower when going faster

        //print("velocity: " + theRB.velocity.magnitude);

        //0-27

        //calculatedDrag = (3 * drag) - (2 * drag * (theRB.velocity.magnitude/28f));
        //print("calculatedDrag: " + calculatedDrag);

        //forward = transform.forward * speedInput * forwardAccel * 1000f;
        //print(1 + 9 * (theRB.velocity.magnitude/27.5f));
        //print("second: " + (1 + (forwardAccel - 1) * (theRB.velocity.magnitude / 27.5f)));

    }

    public float zAngleLimit = 30f;
    public float xAngleLimit = 60f;

    private void FixedUpdate()
    {

        //print("rigidbody.velocity.magnitude " + theRB.velocity.x);
        
        /*
        if(localVelocity.z > 0.1f)
        {
            print("forward");
        }else
        {
            print("backward");
        }
        */

        //print("Grounded: " + grounded + "   number: " + forwardGas * forwardAccel * 1000f);

        grounded = false;
        
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;
        }

        if (grounded)
        {
            //theRB.drag = calculatedDrag;
            theRB.drag = drag;
            //theRB.AddForce(transform.forward * forwardGas * forwardAccel * 1000f);
            //if (speedInput > 0) theRB.AddForce(transform.forward * speedInput * (5 + (forwardAccel - 5) * (theRB.velocity.magnitude / 27.5f)) * 1000f);
            //if (speedInput > 0) theRB.AddForce(transform.forward * speedInput * (1 + (forwardAccel - 1) * (theRB.velocity.magnitude / 27.5f)) * 1000f);
            if (speedInput > 0) theRB.AddForce(transform.forward * speedInput * forwardAccel * 1000f);
            if(speedInput <= 0) theRB.AddForce(transform.forward * speedInput * reverseAccel * 1000f);
            theRB.AddForce(-Vector3.up * downforce);
        }
        else
        {
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }
}
