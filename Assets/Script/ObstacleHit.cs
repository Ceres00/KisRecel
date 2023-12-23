using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-2f, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            collision.rigidbody.velocity = new Vector2(Mathf.MoveTowards(collision.rigidbody.velocity.x, -2f, -(2f / 1f) * Time.deltaTime), collision.rigidbody.velocity.y);
        }
        else if (collision.collider.tag == "Player2")
        {
            Destroy(gameObject);
            collision.rigidbody.velocity = new Vector2(Mathf.MoveTowards(collision.rigidbody.velocity.x, -2f, -(2f/1f) * Time.deltaTime), collision.rigidbody.velocity.y);
        }
    }
}
