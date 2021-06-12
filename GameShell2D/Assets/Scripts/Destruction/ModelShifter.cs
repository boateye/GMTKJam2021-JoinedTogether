using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelShifter : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnCollisionEnter(Collision collision)
    {
        CarController player = collision.gameObject.GetComponent<CarController>();
        if (player != null)
        {
            //Swaps current object with the "destroyed" version
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
