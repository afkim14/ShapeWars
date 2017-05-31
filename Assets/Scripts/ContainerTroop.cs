using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainerTroop : Troop {
    
    public Troop insideTroop;

    // Use this for initialization
    void Start()
    {
        maxHealth = 7;
        currHealth = maxHealth;
        transform.localScale = new Vector3(0.1727068f, 0.1727068f, 0.1727068f);
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

    private void OnDestroy()
    {
        float x = direction.x;
        float y = direction.y;
        float interval;

        if (x != 0) {
            interval = x / Mathf.Abs(x);
            for (int i = 0; i < 4; i++)
            {
                Vector2 newPos = new Vector2(transform.position.x - interval, transform.position.y);
                Troop tempInsideTroop = Instantiate(insideTroop, newPos, transform.rotation);
                tempInsideTroop.direction = direction;
                interval++;
            }
        }
        else {
            interval = y / Mathf.Abs(y);
            for (int i = 0; i < 4; i++)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - interval);
                Troop tempInsideTroop = Instantiate(insideTroop, newPos, transform.rotation);
                tempInsideTroop.direction = direction;
                interval++;
            }
        }
    }
}
