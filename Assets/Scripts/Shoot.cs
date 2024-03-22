using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private LayerMask layermask;
    
    // Update is called once per frame
    void Update()
    {
        Ray();
    }

    private void Ray()
    {
        Debug.DrawRay(shootPoint.transform.position, Vector3.forward * 20f, Color.green);

        if (Physics.Raycast(shootPoint.transform.position,
                transform.TransformDirection(Vector3.forward), out RaycastHit hit, 1000f, layermask))
        {
            Debug.Log($"Hit{hit.collider.gameObject.tag}");
            Debug.DrawRay(shootPoint.transform.position, Vector3.forward * 1000f, Color.magenta);
            //Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Hit nothing");
        }
    }
}
