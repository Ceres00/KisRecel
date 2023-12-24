using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Snowball")
        Destroy(gameObject);
    }
}
