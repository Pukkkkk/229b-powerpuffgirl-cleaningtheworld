using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float maxLenght;

    [SerializeField] private ParticleSystem muzzleParticles;
    [SerializeField] private ParticleSystem hitParticles;

    [SerializeField] private float damage;
    [SerializeField] private float rocketHP;
    [SerializeField] private float curRocketHP;

    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject obsDamage;

    public GameManager gameManager;
    
    private void Awake()
    {
        rocketHP = curRocketHP;
        beam.enabled = false;
        
        //obsDamage = GetComponent<Damage>().
    }

    private void Start()
    {
        rocketHP = 100;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Activate();
        else if (Input.GetMouseButtonUp(0)) Deactivate();

        healthBar.fillAmount = Mathf.Clamp( curRocketHP / rocketHP, 0, 1);
    }

    private void FixedUpdate()
    {
        if (!beam.enabled) return;

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, maxLenght);
        Vector3 hitPosition = cast ? hit.point : muzzlePoint.position + muzzlePoint.forward * maxLenght;
        
        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, hitPosition);

        hitParticles.transform.position = hitPosition;

        if (cast && hit.collider.TryGetComponent(out Damage damageable))
        {
            damageable.ApplyDamage(damage * Time.fixedDeltaTime);
        }
    }

    private void Activate()
    {
        beam.enabled = true;
        
        muzzleParticles.Play();
        hitParticles.Play();
    }

    private void Deactivate()
    {
        beam.enabled = false;
        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, muzzlePoint.position);
        
        muzzleParticles.Stop();
        hitParticles.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        gameManager.GameOver();
        Debug.Log("Game Over!");
    }
}
