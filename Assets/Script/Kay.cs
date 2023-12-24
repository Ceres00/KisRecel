using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kay : MonoBehaviour
{
    public Rigidbody2D rb;
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(2f, -2f);
    }
}
