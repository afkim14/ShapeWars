using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Troop : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float maxHealth;
    public float currHealth;
    public float currSpeed;
    public Vector3 direction;
    public float minSpeed = 0.5f;
    public float speedMult;
    public GameObject deathParticle;
    public GameAdmin ga;
    public bool rezzed;

    public bool frozen;
    public float temp_speedMult;
    public float frozenTime;
    public float frozenCooldown = 2.0f;

    public int cost;

    public void setupDirection()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            direction = new Vector3(0, -1, 0);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            transform.Translate(direction * Time.deltaTime * speedMult);
        }

        if (frozen)
        {
            frozenTime += Time.deltaTime;
            if (frozenTime > frozenCooldown)
            {
                speedMult = temp_speedMult;
                frozen = false;
                frozenTime = 0.0f;
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (direction.x == 0) { currSpeed = Mathf.Abs(direction.y); }
        else { currSpeed = Mathf.Abs(direction.x); }

        if ((col.CompareTag("WallDownLeft")) || (col.CompareTag("WallUpLeft")))
        {
            direction = new Vector3(-1 * currSpeed, 0, 0);
        }
        else if ((col.CompareTag("WallLeftDown")) || (col.CompareTag("WallRightDown")))
        {
            direction = new Vector3(0, -1 * currSpeed, 0);
        }
        else if ((col.CompareTag("WallDownRight")) || (col.CompareTag("WallUpRight")))
        {
            direction = new Vector3(1 * currSpeed, 0, 0);
        }
        else if ((col.CompareTag("WallRightUp")) || (col.CompareTag("WallLeftUp")))
        {
            direction = new Vector3(0, 1 * currSpeed, 0);
        }
    }

    public virtual void Damage(float dmg)
    {
        if (currHealth - dmg <= 0)
        {
            if (!rezzed)
            {
                ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
                string type = gameObject.GetComponent<Troop>().name;
                Vector2 pos = new Vector2(gameObject.GetComponent<Troop>().transform.position.x, gameObject.GetComponent<Troop>().transform.position.y);
                Vector2 dir = new Vector2(gameObject.GetComponent<Troop>().direction.x, gameObject.GetComponent<Troop>().direction.y);
                TroopCopy tp = new TroopCopy(type, pos, dir);
                ga.deadTroops.Add(tp);
            }
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        currHealth -= dmg;
    }

    public void Slow(float slow_factor)
    {
        float x = direction.x;
        float y = direction.y;

        if (x != 0)
        {
            if (x > 0) {
                direction.x = x - slow_factor;
                if (direction.x < minSpeed) { direction.x = minSpeed; }
            }
            else {
                direction.x = x + slow_factor;
                if (direction.x > -minSpeed) { direction.x = -minSpeed; }
            }
        } else
        {
            if (y > 0) {
                direction.y = y - slow_factor;
                if (direction.y < minSpeed) { direction.y = minSpeed; }
            }
            else {
                direction.y = y + slow_factor;
                if (direction.y > -minSpeed) { direction.y = -minSpeed; }
            }
        }
    }

    private void OnMouseDown()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        if ((ga.destroySelectButtonPressed) && (ga.destroySelectsLeft > 0))
        {
            Destroy(gameObject);
            ga.destroySelectsLeft--;
        }
    }
}
