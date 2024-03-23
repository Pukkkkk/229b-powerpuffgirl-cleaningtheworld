using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer beam;

    [SerializeField] private Transform muzzlePoint;

    [SerializeField] private float maxLenght;

    private void Awake()
    {
        beam.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Activate();
        else if (Input.GetMouseButtonUp(0)) Deactivate();
    }

    private void FixedUpdate()
    {
        if (!beam.enabled) return;

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, maxLenght);
        Vector3 hitPosition = cast ? hit.point : muzzlePoint.position + muzzlePoint.forward * maxLenght;
        
        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, hitPosition);
    }

    private void Activate()
    {
        beam.enabled = true;
    }

    private void Deactivate()
    {
        beam.enabled = false;
        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, muzzlePoint.position);
    }
}
