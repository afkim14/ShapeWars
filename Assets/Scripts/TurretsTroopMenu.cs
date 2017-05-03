using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TurretsTroopMenu : MonoBehaviour {

    public GameAdmin ga;
    private Turret[] turrets;
    private Troop[] troops;
    private int num_of_turrets = 11;
    private int num_of_troops = 11;

    public Turret turret0;
    public Turret turret1;
    public Turret turret2;

    public Troop troop0;

    // Use this for initialization
    void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        ga.can_place_turret = true;
        turrets = new Turret[num_of_turrets];
        troops = new Troop[num_of_troops];

        turrets[0] = turret0;
        turrets[1] = turret1;
        turrets[2] = turret2;

        troops[0] = troop0;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(troops[0], new Vector2(-10.59f, 0.2f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }
	}

    public void CreateTurret()
    {
        if (!ga.holding_turret)
        {
            string turret_name = EventSystem.current.currentSelectedGameObject.name;
            int turret_index = int.Parse(turret_name);
            Turret turret = turrets[turret_index];

            Vector2 buttonpos = EventSystem.current.currentSelectedGameObject.transform.position;
            Turret t = Instantiate(turret, buttonpos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

            // tell admin you are holding this turret
            ga.holding_turret = true;
            ga.curr_turret_held = t;
        } else
        {
            Destroy(ga.curr_turret_held.gameObject);
            ga.holding_turret = false;
            ga.curr_turret_held = null;
        }
    }

    public void PlaceTurret()
    {
        if (ga.holding_turret)
        {
            if (ga.can_place_turret)
            {
                // fix the turret in place
                ga.curr_turret_held.placed = true;
                Vector3 pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                ga.curr_turret_held.placed_pos = Camera.main.ScreenToWorldPoint(pos);
                ga.curr_turret_held.GetComponent<Collider2D>().isTrigger = false;
                ga.holding_turret = false;
                ga.curr_turret_held = null;
            }
        }
    }
}
