using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultMovement : MonoBehaviour
{

    private Rigidbody theRB;
    public float gravityForce = 10f;
    public Vector3 com = new Vector3(0f,-0.5f,0f);

    // Start is called before the first frame update
    void Start()
    {
        theRB = gameObject.GetComponent<Rigidbody>();
        theRB.centerOfMass = com;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
        theRB.AddForce(Vector3.up * -gravityForce * 100f);
    }
}
