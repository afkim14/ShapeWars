using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Troop : MonoBehaviour {

    public Rigidbody2D rb2d;
    public int maxHealth;
    public int currHealth;
    public float currSpeed;
    public Vector3 direction;
    public float minSpeed = 0.5f;
    public GameObject deathParticle;
    private GameAdmin ga;

    private void OnTriggerEnter2D(Collider2D col)
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

    public void Damage(int dmg)
    {
        if (currHealth - dmg <= 0)
        {
            // delete it from active troops
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed")+1);
            PlayerPrefs.SetInt("dp_score", PlayerPrefs.GetInt("dp_score") + 100);
            PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 50);
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
        if (ga.destroySelectsLeft > 0)
        {
            Destroy(gameObject);
            ga.destroySelectsLeft--;
        }
    }
}
