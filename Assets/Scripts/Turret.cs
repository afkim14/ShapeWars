using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameAdmin ga;
    public bool placed;
    public Vector3 placed_pos;
    public bool troop_in_range;
    public List<Troop> currentCollisions = new List<Troop>();
    public bool paralyzed;
    public float paralyzedTime;
    public float paralyzedLimit = 3.0f;
    public int cost;

    // Use this for initialization
    void Start()
    {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        placed = false;
        troop_in_range = false;
        paralyzed = false;
        transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!placed) // follow mouse
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        if (paralyzed)
        {
            paralyzedTime += Time.deltaTime;
            if (paralyzedTime > paralyzedLimit)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f, 255.0f);
                paralyzed = false;
                paralyzedTime = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Turret"))
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(193.0f/255.0f, 7.0f/255.0f, 7.0f/255.0f);
            ga.can_place_turret = false;
        } else
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            ga.can_place_turret = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Turret"))
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(193.0f / 255.0f, 7.0f / 255.0f, 7.0f / 255.0f);
            ga.can_place_turret = false;
            // show somehow that turret cannot be placed
        } else
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            ga.can_place_turret = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Turret"))
        {
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
            ga.can_place_turret = true;
        }
    }

}
