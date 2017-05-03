using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletTime;
    public float maxBulletTime = 2.0f;
    private float maxSpeed = 5.0f;

    // Use this for initialization
    void Start () {
        transform.localScale = new Vector3(0.1855172f, 0.1855172f, 0.1855172f);
    }
	
	// Update is called once per frame
	void Update () {

        // make sure bullet doesn't last forever
        bulletTime += Time.deltaTime;
        if (bulletTime >= maxBulletTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            col.GetComponent<Troop>().Damage(1);
            Destroy(gameObject);
        }
    }
}
