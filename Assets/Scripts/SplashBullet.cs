using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBullet : Bullet {

    public ParticleSystem ps;

	// Use this for initialization
	void Start () {
        maxBulletTime = 2.0f;
        transform.localScale = new Vector3(0.5358578f, 0.5358578f, 0.5358578f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            Instantiate(ps, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
