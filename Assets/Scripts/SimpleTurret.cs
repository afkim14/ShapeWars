using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurret : Turret {

    public Transform shootingPoint;
    public Bullet bullet;
    public Transform target;
    private int bulletSpeed = 6;
    private float shootTime;
    private float shootInterval = 0.6f;

    // Update is called once per frame
    void Update () {
        cost = ga.turret_costs[0];
        if (placed && !paralyzed)
        {
            if (currentCollisions.Count > 0)
            {
                Troop enemy = currentCollisions[0];
                if (enemy.currHealth > 0)
                {
                    shootTime += Time.deltaTime;
                    if (shootTime >= shootInterval)
                    {
                        Vector2 direction = enemy.transform.position - transform.position;
                        Bullet bulletClone;
                        bulletClone = Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
                        bulletClone.bulletSender = gameObject.GetComponent<Turret>();
                        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                        shootTime = 0.0f;
                    }
                } else
                {
                    currentCollisions.RemoveAt(0);
                }
            }
        }
	}


}
