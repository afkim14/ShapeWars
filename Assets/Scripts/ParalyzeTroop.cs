using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParalyzeTroop : Troop {

    public int turretsParalyzed;
    private bool hasShield;
    public Sprite noShieldObject;

	// Use this for initialization
	void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        turretsParalyzed = 0;
        hasShield = true;
        maxHealth = 1;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1055172f, 0.1055172f, 0.1055172f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speedMult = 2.0f;
        setupDirection();
        cost = ga.troop_costs[5];
    }

    public override void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            transform.Translate(direction * Time.deltaTime * speedMult);
        }

        if (turretsParalyzed >= 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = noShieldObject;
            hasShield = false;
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

    public override void OnTriggerEnter2D(Collider2D col)
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

        if (col.CompareTag("Bullet"))
        {
            if (turretsParalyzed < 3) {
                col.gameObject.GetComponent<Bullet>().bulletSender.paralyzed = true;
                col.gameObject.GetComponent<Bullet>().bulletSender.GetComponent<SpriteRenderer>().color = new Color(218.0f/255.0f, 53.0f/255.0f, 50.3f/255.0f);
                turretsParalyzed++;
            }
        }
    }

    public override void Damage(float dmg)
    {
        if (!hasShield)
        {
            if (currHealth - dmg <= 0)
            {
                if (!rezzed)
                {
                    string type = gameObject.GetComponent<Troop>().name;
                    Vector2 pos = new Vector2(gameObject.GetComponent<Troop>().transform.position.x, gameObject.GetComponent<Troop>().transform.position.y);
                    Vector2 dir = new Vector2(gameObject.GetComponent<Troop>().direction.x, gameObject.GetComponent<Troop>().direction.y);
                    TroopCopy tp = new TroopCopy(type, pos, dir);
                    ga.deadTroops.Add(tp);
                }
                Instantiate(deathParticle, transform.position, transform.rotation);
                Destroy(gameObject);
                PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
                PlayerPrefs.SetInt("dp_score", PlayerPrefs.GetInt("dp_score") + 100);
                PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 50);
            }
            currHealth -= dmg;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 8);
    }
}
