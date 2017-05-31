using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : Bullet {

    private float slow_factor;
    private int rotation = 0;

    // Use this for initialization
    void Start () {
        slow_factor = 0.2f;
        maxBulletTime = 2.0f;
        transform.localScale = new Vector3(0.3154514f, 0.3154514f, 0.3154514f);
    }
	
	// Update is called once per frame
	void Update () {
        rotation+=5;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            col.GetComponent<Troop>().Slow(slow_factor);
            Destroy(gameObject);
        }
    }
}
