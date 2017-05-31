using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSquare : MonoBehaviour {

    public Rigidbody2D rb2d;
    public GameObject deathParticle;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (transform.position.y < 0)
        {
            rb2d.AddForce(Vector2.up * 100.0f); 
        } else
        {
            rb2d.AddForce(Vector2.down * 100.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(deathParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
        Destroy(col.gameObject);
    }
}
