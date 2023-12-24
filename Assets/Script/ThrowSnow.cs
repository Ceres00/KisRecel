using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnow : MonoBehaviour
{
    public GameObject snowball;
    public float launchForce;
    public Transform shotPoint;
    public Transform target;
   
    void Shoot()
    {
        GameObject newSnowball = Instantiate(snowball, shotPoint.position, shotPoint.rotation);
        newSnowball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
    void Update()
    {
        Vector2 SnowPosition = transform.position;
        Vector2 AimPosition = target.position;
        Vector2 direction = AimPosition - SnowPosition;
        transform.right = direction;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
