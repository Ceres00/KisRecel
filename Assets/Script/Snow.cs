using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    Rigidbody2D rb;
    public Level2Movement L1;
    public Level2Movement2 L2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        L1 = Ref.Instance.level2Mov;
        L2 = Ref.Instance.level2Mov2;
        //L1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Level2Movement>();
        //L2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Level2Movement2>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            L1.L++;
        }
        else if (collision.collider.tag == "Player2")
        {
            L2.L++;
        }
        if (collision.collider.tag != "Snowball")
        {
            Destroy(gameObject);
        }
    }
}
