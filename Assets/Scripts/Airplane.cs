using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] private Rigidbody rocketRb;

    [SerializeField] private float enginePowerThrust, liftBooter, drag, angularDrag;

    private void FixedUpdate()
    {
        Thrust();
        Lift();
        Drag();
        AngularDrag();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRb.AddForce(transform.forward * enginePowerThrust);    
        }
    }

    private void Lift()
    {
        Vector3 lift = Vector3.Project(rocketRb.velocity, transform.forward);
        rocketRb.AddForce(transform.up * lift.magnitude * liftBooter);
    }

    private void Drag()
    {
        rocketRb.drag = rocketRb.velocity.magnitude * drag;
        rocketRb.angularDrag = rocketRb.velocity.magnitude * angularDrag;
    }

    private void AngularDrag()
    {
        rocketRb.AddTorque( Input.GetAxis("Horizontal") * transform.forward * -1 );
        rocketRb.AddTorque(Input.GetAxis("Vertical") * transform.right);
    }
}
