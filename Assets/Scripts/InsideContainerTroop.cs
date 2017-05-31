using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideContainerTroop : Troop {

    // Use this for initialization
    void Start()
    {
        maxHealth = 7;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            direction = new Vector3(0, -1, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            transform.Translate(direction * Time.deltaTime * 2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            //rb2d.AddForce((Vector2.right * 2.0f));
        }
    }
}
