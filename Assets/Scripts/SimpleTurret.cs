using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurret : Turret {

    public Transform shootingPoint;
    public Bullet bullet;
    public Transform target;
    private int bulletSpeed = 2;
    private float shootTime;
    private float shootInterval = 0.5f;

    // Update is called once per frame
    void Update () {
		if (placed)
        {
            if (GameObject.FindGameObjectWithTag("Troop") != null)
            {
                if (troop_in_range)
                {
                    //shootTime += Time.deltaTime;
                    //if (shootTime >= shootInterval)
                    //{
                    target = GameObject.FindGameObjectWithTag("Troop").gameObject.transform;
                    Vector2 direction = target.transform.position - transform.position;
                    Bullet bulletClone;
                    bulletClone = Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
                    bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                    shootTime = 0.0f;
                    //}
                }
            }
        }
	}


}
