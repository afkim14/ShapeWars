using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTroop : Troop
{
    private float speed;

    // Use this for initialization
    void Start()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        maxHealth = 10;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
        speed = 0.05f;
        cost = ga.troop_costs[4];
    }

    public override void Damage(float dmg)
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
            ga.userTroopAlive = false;
        }

        currHealth -= dmg;
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector2 direction = new Vector2();
        if (Input.GetKey(KeyCode.A)) { direction = new Vector2(-1, 0); }
        else if (Input.GetKey(KeyCode.W)) { direction = new Vector2(0, 1); }
        else if (Input.GetKey(KeyCode.D)) { direction = new Vector2(1, 0); }
        else if (Input.GetKey(KeyCode.S)) { direction = new Vector2(0, -1); }
        transform.Translate(direction * speed);

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

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 500);
    }
}
        
