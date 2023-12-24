using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRace : MonoBehaviour
{
    Player1Movement Score1;
    Player2Movement Score2;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject death;
    public GameObject win;
    public GameObject tie;
    public GameObject back;

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
            Level1.SetActive(false);
            death.SetActive(true);
            StartCoroutine(NextLevel());
        }
        else if (Score2.L > Score1.L)
        {
            Level1.SetActive(false);
            win.SetActive(true);
            StartCoroutine(NextLevel());
        }
        else
        {
            Level1.SetActive(false);
            tie.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Finish();
        }
        else if (collision.tag == "Player2")
        {
            Finish();
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5f);
        tie.SetActive(false);
        win.SetActive(false);
        death.SetActive(false);
        Level2.SetActive(true);
        back.SetActive(true);
        Destroy(gameObject);
    }
}
