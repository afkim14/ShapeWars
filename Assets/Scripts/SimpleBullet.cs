using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

    // Use this for initialization
    void Start()
    {
        dmg = 1.0f;
        maxBulletTime = 2.0f;
        transform.localScale = new Vector3(0.1855172f, 0.1855172f, 0.1855172f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            col.GetComponent<Troop>().Damage(dmg);
            Destroy(gameObject);
        }
    }
}
