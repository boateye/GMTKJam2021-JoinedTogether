using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelShifter : MonoBehaviour
{
    public GameObject destroyedVersion;
    //Swaps current object with the "destroyed" version
    /*Instantiate(destroyedVersion, transform.position, transform.rotation);
    Destroy(gameObject);*/

    // imported controls to test modelchanger script
    /*InputController controls;
    private Vector2 leftStick;
    private float rightTrigger;
    private float leftTrigger;

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

    private void OnMouseDown()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }*/
}
