using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassModelShifter : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnCollisionEnter(Collision collision)
    {
        SpringJoint vault = collision.gameObject.GetComponent<SpringJoint>();
        CarController player = collision.gameObject.GetComponent<CarController>();
        if (vault != null || player != null)
        {
            //Swaps current object with the "destroyed" version
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
