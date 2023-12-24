using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Movement : MonoBehaviour
{
    private float horizontal;
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
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        float targetVelocityX = horizontal * speed;
        float accelerationRate = horizontal == 0 ? deceleration : acceleration;
        rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, targetVelocityX, accelerationRate * Time.deltaTime), rb.velocity.y);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x * maxSpeed), rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitScan")
        {
            rb.velocity = new Vector2(0f, rb.velocity.x);
            Destroy(collision.gameObject);
            L++;
        }
    }
}