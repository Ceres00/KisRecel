using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-3.5f, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "StormHit")
        {
            this.transform.position = new Vector2(18f, 0f);
        }
    }
}
