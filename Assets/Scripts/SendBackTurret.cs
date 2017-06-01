using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBackTurret : Turret {

    public Transform shootingPoint;
    public SendBackBullet bullet;
    public Transform target;
    private int bulletSpeed = 4;
    private float shootTime;
    private float shootInterval = 1.5f;

    void Update()
    {
        cost = ga.turret_costs[4];
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
                        SendBackBullet bulletClone;
                        bulletClone = Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
                        bulletClone.bulletSender = gameObject.GetComponent<Turret>();
                        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                        shootTime = 0.0f;
                    }
                }
                else
                {
                    currentCollisions.RemoveAt(0);
                }
            }
        }
    }
}
