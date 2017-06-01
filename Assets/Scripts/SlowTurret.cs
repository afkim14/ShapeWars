using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTurret : Turret {

    public Transform shootingPoint;
    public Transform shootingPoint2;
    private Transform[] shootingPoints;
    public SlowBullet bullet;
    private Transform target;
    private Transform target2;
    private int bulletSpeed = 4;
    private float shootTime;
    private float shootInterval = 1.0f;

    // Update is called once per frame
    void Update()
    {
        cost = ga.turret_costs[3];
        if (placed && !paralyzed)
        {
            if (currentCollisions.Count > 0)
            {
                shootingPoints = new Transform[] { shootingPoint, shootingPoint2 };
                int troopCount = 0;
                Troop[] enemies = new Troop[2];
                enemies[0] = currentCollisions[0];
                troopCount++;
                if (currentCollisions.Count > 1) { enemies[1] = currentCollisions[1]; troopCount++; }
                for (int i = 0; i < troopCount; i++)
                {
                    Troop enemy = enemies[i];
                    if ((enemy.currHealth > 0) || (enemy.currSpeed != enemy.minSpeed))
                    {
                        shootTime += Time.deltaTime;
                        if (shootTime >= shootInterval)
                        {
                            Vector2 direction = enemy.transform.position - transform.position;
                            SlowBullet bulletClone;
                            bulletClone = Instantiate(bullet, shootingPoints[i].transform.position, shootingPoints[i].transform.rotation);
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
}
