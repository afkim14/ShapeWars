using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletTime;
    public float maxBulletTime;
    public int dmg;

    // Use this for initialization
    void Start () {
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
}
