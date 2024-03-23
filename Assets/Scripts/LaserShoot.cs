using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopShoot();
        }
    }

    private void Shoot()
    {
        laser.SetActive(true);
    }

    private void StopShoot()
    {
        laser.SetActive(false);
    }
}
