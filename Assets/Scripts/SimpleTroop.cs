using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTroop : Troop {

    // Use this for initialization
    void Start()
    {
        maxHealth = 30;
        maxSpeed = 2;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            rb2d.AddForce((Vector2.right * 2.0f));
        } else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            rb2d.AddForce((Vector2.down * 2.0f));
        }
    }

    void FixedUpdate()
    {
        //limiting the speed (x)
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        //limiting the speed (y)
        if (rb2d.velocity.y > maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed);
        }
        if (rb2d.velocity.y < -maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -maxSpeed);
        }
    }
}
