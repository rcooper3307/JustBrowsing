using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bullet;
    public Transform shootPoint;
    [Space(20)]
    public int speed;
    public float movement;
    public GameObject burst;
    private BHellManager manager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("BHController").GetComponent<BHellManager>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal"); //use A&D or arrowkeys for up and down

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        //if(movement != 0 || Input.GetKeyDown(KeyCode.Space))
        //{
        //    manager.GetComponent<BHellManager>().seenStart();
        //}
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (rb.velocity.x, -movement * speed);

    }

    public void takeDamage()
    {
        manager.playerHit();
        manager.GetComponent<BHellManager>().TakeDamage();
        Instantiate(burst, transform.position, Quaternion.identity);
    }

    void Shoot()
    {
        GameObject go = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        go.GetComponent<Bullet>().bulletDirection("right");
    }
}
