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
        maxHealth = 18;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1055172f, 0.1055172f, 0.1055172f);
        speed = 0.065f;
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
            PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 5);
            ga.userTroopAlive = false;
        }

        currHealth -= dmg;
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector2 direction = new Vector2();
        if (Input.GetKey(KeyCode.J)) { direction = new Vector2(-1, 0); }
        else if (Input.GetKey(KeyCode.I)) { direction = new Vector2(0, 1); }
        else if (Input.GetKey(KeyCode.L)) { direction = new Vector2(1, 0); }
        else if (Input.GetKey(KeyCode.K)) { direction = new Vector2(0, -1); }
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
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 50);
        ga.userTroopAlive = false;
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

        if (col.CompareTag("Troop"))
        {
            if ((!col.gameObject.GetComponent<Troop>().enhanced) && (!ga.freezeButtonPressed))
            {
                if (col.gameObject.name.Contains("ContainerTroop") && !col.gameObject.name.Contains("InsideContainerTroop"))
                {
                    if (!(col.gameObject.GetComponent<ContainerTroop>().containerBroken))
                    {
                        col.gameObject.GetComponent<Troop>().currHealth += 5;
                        col.gameObject.GetComponent<Troop>().speedMult += 1.0f;
                        col.gameObject.GetComponent<Troop>().GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 248.0f / 255.0f, 0.0f / 255.0f);
                        col.gameObject.GetComponent<Troop>().enhanced = true;
                    }
                }
                else
                {
                    col.gameObject.GetComponent<Troop>().currHealth += 5;
                    col.gameObject.GetComponent<Troop>().speedMult += 1.0f;
                    col.gameObject.GetComponent<Troop>().GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 248.0f / 255.0f, 0.0f / 255.0f);
                    col.gameObject.GetComponent<Troop>().enhanced = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            if (col.gameObject.GetComponent<Troop>().enhanced)
            {
                col.gameObject.GetComponent<Troop>().Damage(5.0f);
                col.gameObject.GetComponent<Troop>().speedMult -= 1.0f;
                col.gameObject.GetComponent<Troop>().GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                col.gameObject.GetComponent<Troop>().enhanced = false;
            }
        }
    }
}
        
