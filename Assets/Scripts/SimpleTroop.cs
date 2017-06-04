using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTroop : Troop {

    // Use this for initialization
    void Start()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        maxHealth = 8;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        speedMult = 1.3f;
        setupDirection();
        cost = ga.troop_costs[0];
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("troops_killed", PlayerPrefs.GetInt("troops_killed") + 1);
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 5);
    }
}
