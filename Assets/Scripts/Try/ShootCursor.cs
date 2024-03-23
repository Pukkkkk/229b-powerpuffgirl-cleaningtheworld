using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCursor : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject rocket;
    private Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - rocket.transform.position;
        float rotation2 = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rocket.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation2);
    }
}
