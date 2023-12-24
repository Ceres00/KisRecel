using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Movement2 : MonoBehaviour
{
    private float horizontal;
    public int L = 0;
    public GameObject Level2;
    public GameObject Win;
    public GameObject Dikpik;
    public GameObject Gift;

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
        horizontal = Input.GetAxisRaw("Horizontal2");
        if(L == 3)
        {
            StartCoroutine(Finito());
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.y, 4f, 10f), rb.velocity.y);
        }
    }
    IEnumerator Finito()
    {
        Gift.SetActive(true);
        yield return new WaitForSeconds(4f);
        Gift.SetActive(false);
        Dikpik.SetActive(true);
        yield return new WaitForSeconds(4f);
        Dikpik.SetActive(false);
        Win.SetActive(true);
    }
}
