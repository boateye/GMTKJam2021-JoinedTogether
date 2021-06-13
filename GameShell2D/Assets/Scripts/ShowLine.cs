using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour
{
    public GameObject car;
    public GameObject vault;
    public LineRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        renderer.SetPosition(0, car.transform.position);
        renderer.SetPosition(1, vault.transform.position);
    }
}
