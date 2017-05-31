using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TurretsTroopMenu : MonoBehaviour {

    public GameAdmin ga;
    public Transform troopEntryPoint;
    private Turret[] turrets;
    private Troop[] troops;
    private int num_of_turrets = 11;
    private int num_of_troops = 11;

    public Turret turret0;
    public Turret turret1;
    public Turret turret2;
    public Turret turret3;

    public Troop troop0;
	public Troop troop1;
    public Troop troop2;
    public Troop troop3;

	int[] spawnIntervals = {100, 200, 300, 400};
	int[] currIntervals = { 100, 100, 100, 100 };

    // Use this for initialization
    void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        ga.can_place_turret = true;
        turrets = new Turret[num_of_turrets];
        troops = new Troop[num_of_troops];

        turrets[0] = turret0;
        turrets[1] = turret1;
        turrets[2] = turret2;
        turrets[3] = turret3;

        troops[0] = troop0;
		troops[1] = troop1;
        troops[2] = troop2;
        troops[3] = troop3;
    }
	
	// Update is called once per frame
	void Update () {
        // creating turrets
		if ((Input.GetKeyDown(KeyCode.Alpha1)) && (currIntervals[0] == spawnIntervals[0]))
        {
			currIntervals[0] = 0;
            Instantiate(troops[0], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
		} else if ((Input.GetKeyDown(KeyCode.Alpha2)) && (currIntervals[1] == spawnIntervals[1])) {
			currIntervals[1] = 0;
			Instantiate(troops[1], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
			PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt ("troops_sent") + 1);
		} else if ((Input.GetKeyDown(KeyCode.Alpha3)) && (currIntervals[2] == spawnIntervals[2]))
        {
			currIntervals[2] = 0;
            Instantiate(troops[2], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
		} else if ((Input.GetKeyDown(KeyCode.Alpha4)) && (currIntervals[3] == spawnIntervals[3]))
        {
			currIntervals[3] = 0;
            Instantiate(troops[3], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
        }

        // flipping turrets
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ga.holding_turret)
            {
                if (ga.curr_turret_held.transform.rotation.z == 0)
                {
                    ga.curr_turret_held.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                } else
                {
                    ga.curr_turret_held.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
            }
        }
		for (int i = 0; i < 4; i++) {
			if (currIntervals [i] != spawnIntervals[i]) {
				currIntervals [i] = currIntervals [i] + 1;
			}
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
                PlayerPrefs.SetInt("turrets_built", PlayerPrefs.GetInt("turrets_built") + 1);
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
