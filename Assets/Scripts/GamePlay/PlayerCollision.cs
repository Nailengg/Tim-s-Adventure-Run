using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            if (!collision.gameObject.activeInHierarchy) return;

            gameManager.AddScore(50);
            gameManager.AddCoin(1);

            CollectCoinEffect(collision.gameObject);
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
        }
    }

    void CollectCoinEffect(GameObject coin)
    {
        Collider2D col = coin.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        SpriteRenderer sr = coin.GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;

        Destroy(coin, 0.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
        Beetle beetle = collision.gameObject.GetComponent<Beetle>();
        if (beetle == null || beetle.IsDead()) return;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y > collision.transform.position.y + 0.5f 
            && rb.velocity.y <= 0)
        {
            beetle.Die();

            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
}
