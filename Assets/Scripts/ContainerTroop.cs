using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainerTroop : Troop {
    
    public Troop insideTroop;
    private int troopsMade = 0;
    private float currTime = 0.0f;
    private float currInterval = 1.0f;

    // Use this for initialization
    void Start()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        maxHealth = 7;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1727068f, 0.1727068f, 0.1727068f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speedMult = 2.0f;
        setupDirection();
        cost = ga.troop_costs[3];
    }

    public override void Update()
    {
        if (currHealth <= 0)
        {
            currTime += Time.deltaTime;
            if (currTime > currInterval)
            {
                Troop tempInsideTroop = Instantiate(insideTroop, transform.position, transform.rotation);
                tempInsideTroop.direction = direction;
                currTime = 0.0f;
                troopsMade++;
            }
        } else
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                transform.Translate(direction * Time.deltaTime * speedMult);
            }
        }

        if (troopsMade == 10)
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
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

    public override void Damage(int dmg)
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
            PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
            PlayerPrefs.SetInt("dp_score", PlayerPrefs.GetInt("dp_score") + 100);
            PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 50);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(77.0f/255.0f, 77.0f/255.0f, 77.0f/255.0f);
        }

        currHealth -= dmg;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 300);
    }
}
