using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralTurret : Turret {

    public Transform shootingPoint1;
    public Transform shootingPoint2;
    public Transform shootingPoint3;
    public Transform shootingPoint4;
    public Transform shootingPoint5;
    public Transform shootingPoint1ref;
    public Transform shootingPoint2ref;
    public Transform shootingPoint3ref;
    public Transform shootingPoint4ref;
    public Transform shootingPoint5ref;
    private Transform[] shootingPoints;
    private Transform[] shootingPointsRef;
    public Bullet bullet;
    private float bulletTime;
    private int bulletSpeed = 30;
    private float shootInterval = 0.5f;
    private int rotation = 0;
	
	// Update is called once per frame
	void Update () {
        cost = ga.turret_costs[2];
        shootingPoints = new Transform[5] { shootingPoint1, shootingPoint2, shootingPoint3, shootingPoint4, shootingPoint5};
        shootingPointsRef = new Transform[5] { shootingPoint1ref, shootingPoint2ref, shootingPoint3ref, shootingPoint4ref, shootingPoint5ref };
        if (placed)
        {
            // rotate turret
            rotation++;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));

            // shoot
            if (placed && !paralyzed)
            {
                if (currentCollisions.Count > 0)
                {
                    // check if troop's not dead
                    for (int j = 0; j < currentCollisions.Count; j++) { if (currentCollisions[j].currHealth <= 0) { currentCollisions.Remove(currentCollisions[j]); } }
                    bulletTime += Time.deltaTime;
                    if (bulletTime >= shootInterval)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Vector2 direction = shootingPointsRef[i].position - shootingPoints[i].position;
                            Bullet bulletClone = Instantiate(bullet, shootingPoints[i].transform.position, shootingPoints[i].transform.rotation);
                            bulletClone.bulletSender = gameObject.GetComponent<Turret>();
                            bulletClone.maxBulletTime = 1.0f;
                            bulletClone.dmg = 5;
                            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                            bulletTime = 0.0f;
                        }
                    }
                }
            }
        }
    }
}
