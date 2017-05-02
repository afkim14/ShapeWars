using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour {

    public Rigidbody2D rb2d;
    public int maxSpeed = 2;
    public int maxHealth = 30;
    public int currHealth;

    // Use this for initialization
    void Start () {
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1655172f, 0.1655172f, 0.1655172f);
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

    public void Damage(int dmg)
    {
        if (currHealth - dmg <= 0)
        {
            Destroy(gameObject);
        }

        currHealth -= dmg;
    }
}
