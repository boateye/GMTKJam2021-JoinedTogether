using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelShifter : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnCollisionEnter(Collision collision)
    {
        SpringJoint vault = collision.gameObject.GetComponent<SpringJoint>();
        if (vault != null)
        {
            //Swaps current object with the "destroyed" version
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
