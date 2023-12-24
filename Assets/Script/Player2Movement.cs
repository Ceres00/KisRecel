using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private float vertical;
    public int L = 0;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 10f;
    [SerializeField] private float maxSpeed = 12f;

    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical2");
    }

    private void FixedUpdate()
    {
        float targetVelocityY = vertical * speed;
        float accelerationRate = vertical == 0 ? deceleration : acceleration;
        rb.velocity = new Vector2(rb.velocity.x, Mathf.MoveTowards(rb.velocity.y, targetVelocityY, accelerationRate * Time.deltaTime));

        if (Mathf.Abs(rb.velocity.y) > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y * maxSpeed));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.MoveTowards(rb.velocity.y, -4f, 10f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitScan2")
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            Destroy(collision.gameObject);
        }
    }
}
