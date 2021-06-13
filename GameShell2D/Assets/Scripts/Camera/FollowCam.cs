using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3(0f,80f,-30f);
    public float trackSpeed = 1f;

    private void Start()
    {
        transform.position = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position,target.transform.position + offset, Time.deltaTime * trackSpeed);
    }
}
