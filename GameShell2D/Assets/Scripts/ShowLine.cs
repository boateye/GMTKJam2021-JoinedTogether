using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour
{
    public GameObject car;
    public GameObject vault;
    public LineRenderer renderer;

    public Vector3 vaultOffset, carOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 worldPos = transform.TransformPoint(carOffset);
        //print(transform.TransformPoint(car.transform.position));
        //print(worldPos);
        //worldPos = worldPos.
        //renderer.SetPosition(0, car.transform.position + carOffset);
        //renderer.SetPosition(0, worldPos);
        renderer.SetPosition(0, car.transform.position);
        //renderer.SetPosition(0, car.transform.position + carOffset);
        renderer.SetPosition(1, vault.transform.position);
        //renderer.SetPosition(1, vault.transform.position + vaultOffset);
    }
}
