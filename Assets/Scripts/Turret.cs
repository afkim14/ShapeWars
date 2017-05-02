using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameAdmin ga;
    public bool placed;
    public Vector3 placed_pos;
    public Transform shootingPoint;
    public Bullet bullet;
    public Transform target;
    private int bulletSpeed;

    // Use this for initialization
    void Start()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        placed = false;
        transform.localScale = new Vector3(0.1655172f, 0.1655172f, 0.1655172f);
        bulletSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!placed) // follow mouse
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        } else
        {
            if (GameObject.FindGameObjectWithTag("Troop") != null)
            {
                target = GameObject.FindGameObjectWithTag("Troop").gameObject.transform;
                Vector2 direction = target.transform.position - transform.position;
                Bullet bulletClone;
                bulletClone = Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletClone.bulletTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Turret"))
        {
            ga.can_place_turret = false;
            // show somehow that turret cannot be placed
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Turret"))
        {
            ga.can_place_turret = true;
        }
    }

}
