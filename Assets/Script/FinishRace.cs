using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRace : MonoBehaviour
{
    Player1Movement Score1;
    Player2Movement Score2;

    [SerializeField] private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-2f, rb.velocity.y);
    }

    private void Start()
    {
        Score1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1Movement>();
        Score2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Movement>();
    }
    private void Finish()
    {
        if (Score1.L > Score2.L)
        {
            Debug.Log("Player 1 Won!");
        }
        else if (Score2.L > Score1.L)
        {
            Debug.Log("Player 2 Won!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Finish();
            Destroy(gameObject);
        }
        else if (collision.tag == "Player2")
        {
            Finish();
            Destroy(gameObject);
        }
    }
}
