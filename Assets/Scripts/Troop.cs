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
        }

        currHealth -= dmg;
    }
}
