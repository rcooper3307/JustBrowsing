using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHell : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    [Space(20)]
    public bool canShoot;
    public float fireRate;
    public int health;
    public GameObject Bullet;
    public GameObject burst;
    public Transform shootPoint;
    public Transform shootPoint2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if(canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * -1, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCursor>().takeDamage();
            Death();
        }

    }

    public void Damage()
    {
        health--;
        if(health == 0)
        {
            GameObject.FindGameObjectWithTag("BHController").GetComponent<BHellManager>().enemyDeath();

            Death();
        }
    }

    void Shoot()
    {
        GameObject go = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        go.GetComponent<Bullet>().bulletDirection("left");
        go.GetComponent<SpriteRenderer>().color = Color.red;
        if(shootPoint2 != null)
        {
            GameObject go2 = Instantiate(Bullet, shootPoint2.position, Quaternion.identity);
            go2.GetComponent<Bullet>().bulletDirection("left");
            go2.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void Death()
    {
        
        Instantiate(burst, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
