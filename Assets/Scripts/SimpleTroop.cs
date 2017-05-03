using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rb2d.AddForce((Vector2.right * 2.0f));
    }

    void FixedUpdate()
    {

        //limiting the speed without affecting y
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
