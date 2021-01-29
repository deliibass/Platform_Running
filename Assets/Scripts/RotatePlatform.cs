using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float torque;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * torque);
    }

    void FixedUpdate()
    {
        //float turn = Input.GetAxis("Horizontal");
        //rb.AddTorque(transform.forward * torque * Time.deltaTime);
    }
}
