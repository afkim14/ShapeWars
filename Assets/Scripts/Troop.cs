using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour {

    public Rigidbody2D rb2d;
    public int maxSpeed;
    public int maxHealth;
    public int currHealth;

    public void Damage(int dmg)
    {
        if (currHealth - dmg <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed")+1);
            PlayerPrefs.SetInt("dp_score", PlayerPrefs.GetInt("dp_score") + 100);
            PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 50);
        }

        currHealth -= dmg;
    }
}
