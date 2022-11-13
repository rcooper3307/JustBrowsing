using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{
    public int speed = 20;
    public Rigidbody2D rb;
    private int direction; //1 = right / -1 = left
    public bool ifEnemy = false;
    public GameObject ps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !ifEnemy)
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            collision.GetComponent<EnemyBulletHell>().Damage();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && ifEnemy)
        {
            collision.GetComponent<PlayerCursor>().takeDamage();
            Destroy(gameObject);
        }
        else
        {
            if(collision.gameObject.tag == "Border")
            {
                Destroy(gameObject);
            }
        }
    }

    public void bulletDirection(string s)
    {
        switch(s)
        {
            case "right":
                direction = 1;
                break;
            case "left":
                direction = -1;
                ifEnemy = true;
                break;
        }
    }
}
