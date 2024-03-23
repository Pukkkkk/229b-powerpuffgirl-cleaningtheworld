using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float ObsHP;
    [SerializeField] private float curObsHP;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float obsDamage;

    [SerializeField] private RocketLaser health;

    private void Awake()
    {
        curObsHP = ObsHP;
    }

    public void ApplyDamage(float damage)
    {
        if (curObsHP <= 0)return;
        
        curObsHP -= damage;

        if (curObsHP <= 0) Destruct();
    }
    
    private void Destruct()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScoreManager.scoreCount += 100;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<RocketLaser>().
        }
    }
}
