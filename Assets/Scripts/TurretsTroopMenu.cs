using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class TurretsTroopMenu : MonoBehaviour {

    public GameAdmin ga;
    public Transform troopEntryPoint;
    private Turret[] turrets;
    private Troop[] troops;
    private Button[] turret_buttons;
    private Button[] troop_buttons;
    private int num_of_turrets = 11;
    private int num_of_troops = 11;

    public Turret turret0;
    public Turret turret1;
    public Turret turret2;
    public Turret turret3;
    public Turret turret4;

    public Button turret0_button;
    public Button turret1_button;
    public Button turret2_button;
    public Button turret3_button;
    public Button turret4_button;

    public Troop troop0;
	public Troop troop1;
    public Troop troop2;
    public Troop troop3;
    public Troop insideTroop;
    public Troop troop4;
    public Troop troop5;

    public Button troop0_button;
    public Button troop1_button;
    public Button troop2_button;
    public Button troop3_button;
    public Button troop4_button;
    public Button troop5_button;

    // Attacking Player Skills
    public Button speedup_button;
    public int speedup_cost = 1200;
    private float speedUpCurrTime;
    private float sppedUpCooldown = 2.0f;

    public Button rez_button;
    public int rez_cost = 1700;
    private float rezTime;
    private float rezCooldown = 2.0f;

    // sounds
    public AudioSource speedupSound;
    public AudioSource rezSound;
    public AudioSource turretSound;

    //int[] spawnIntervals = {100, 200, 300, 400, 100 };
    //int[] currIntervals = { 100, 100, 100, 100, 100 };

    int[] spawnIntervals = { 0, 0, 0, 0, 0, 0 };
    int[] currIntervals = { 0, 0, 0, 0, 0, 0 };

    // Use this for initialization
    void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        ga.can_place_turret = true;
        turrets = new Turret[num_of_turrets];
        troops = new Troop[num_of_troops];
        turret_buttons = new Button[num_of_turrets];
        troop_buttons = new Button[num_of_troops];

        turrets[0] = turret0;
        turrets[1] = turret1;
        turrets[2] = turret2;
        turrets[3] = turret3;
        turrets[4] = turret4;

        turret_buttons[0] = turret0_button;
        turret_buttons[1] = turret1_button;
        turret_buttons[2] = turret2_button;
        turret_buttons[3] = turret3_button;
        turret_buttons[4] = turret4_button;

        troops[0] = troop0;
		troops[1] = troop1;
        troops[2] = troop2;
        troops[3] = troop3;
        troops[4] = troop4;
        troops[5] = troop5;

        troop_buttons[0] = troop0_button;
        troop_buttons[1] = troop1_button;
        troop_buttons[2] = troop2_button;
        troop_buttons[3] = troop3_button;
        troop_buttons[4] = troop4_button;
        troop_buttons[5] = troop5_button;
    }

    private void FixedUpdate()
    {
        // grey out turrets and troops if no money
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.GetInt("ap_money") >= ga.troop_costs[i])
            {
                troop_buttons[i].interactable = true;
            } else
            {
                troop_buttons[i].interactable = false;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("dp_money") >= ga.turret_costs[i])
            {
                turret_buttons[i].interactable = true;
            } else
            {
                turret_buttons[i].interactable = false;
            }
        }

        // disable skills
        if (PlayerPrefs.GetInt("ap_money") >= speedup_cost) { speedup_button.interactable = true; }
        else { speedup_button.interactable = false; }

        if (PlayerPrefs.GetInt("ap_money") >= rez_cost) { rez_button.interactable = true; }
        else { rez_button.interactable = false; }

        if (PlayerPrefs.GetInt("dp_money") >= ga.destroyCost) {
            if (!ga.destroySelectButtonPressed)
            {
                ga.destroy_button.interactable = true;
            }
        }
        else {
            ga.destroy_button.interactable = false;
        }

        if (PlayerPrefs.GetInt("dp_money") >= ga.freezeCost) { ga.freeze_button.interactable = true; }
        else { ga.freeze_button.interactable = false; }
    }

    // Update is called once per frame
    void Update () {
        // creating turrets
        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (currIntervals[0] == spawnIntervals[0]) && troop_buttons[0].interactable)
        {
			currIntervals[0] = 0;
            Instantiate(troops[0], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[0]);
        } else if ((Input.GetKeyDown(KeyCode.Alpha2)) && (currIntervals[1] == spawnIntervals[1]) && troop_buttons[1].interactable) {
			currIntervals[1] = 0;
			Instantiate(troops[1], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
			PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt ("troops_sent") + 1);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[1]);
        } else if ((Input.GetKeyDown(KeyCode.Alpha3)) && (currIntervals[2] == spawnIntervals[2]) && troop_buttons[2].interactable)
        {
			currIntervals[2] = 0;
            Instantiate(troops[2], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[2]);
        } else if ((Input.GetKeyDown(KeyCode.Alpha4)) && (currIntervals[3] == spawnIntervals[3]) && troop_buttons[3].interactable)
        {
			currIntervals[3] = 0;
            Instantiate(troops[3], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[3]);
        } else if ((Input.GetKeyDown(KeyCode.Alpha5)) && (currIntervals[4] == spawnIntervals[4]) && troop_buttons[4].interactable)
        {
            if (!ga.userTroopAlive)
            {
                currIntervals[4] = 0;
                Instantiate(troops[4], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
                PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
                PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[4]);
                ga.userTroopAlive = true;
            }
        } else if ((Input.GetKeyDown(KeyCode.Alpha6)) && (currIntervals[5] == spawnIntervals[5]) && troop_buttons[5].interactable)
        {
            currIntervals[5] = 0;
            Instantiate(troops[5], new Vector2(troopEntryPoint.position.x, troopEntryPoint.position.y), troopEntryPoint.rotation);
            PlayerPrefs.SetInt("troops_sent", PlayerPrefs.GetInt("troops_sent") + 1);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - ga.troop_costs[5]);
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

        // Attacking Player Skills
        if (Input.GetKeyDown(KeyCode.Comma) && speedup_button.interactable)
        {
            speedupSound.Play();
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - speedup_cost);
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < allObjects.Length; i++)
            {
                GameObject obj = allObjects[i];
                if (obj.activeInHierarchy && obj.CompareTag("Troop"))
                {
                    obj.GetComponent<Troop>().speedMult += 0.5f;
                }
            }

            ga.speedUpButtonPressed = true;
            speedup_button.interactable = false;
        }

        if (Input.GetKeyDown(KeyCode.Period) && rez_button.interactable && ga.deadTroops.Count > 0)
        {
            rezSound.Play();
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") - rez_cost);
            TroopCopy tp = ga.deadTroops[ga.deadTroops.Count - 1];
            Troop newTroop = null;
            if (tp.type.Contains("SquareTroop")) { newTroop = Instantiate(troops[0], tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("ContainerTroop")) { newTroop = Instantiate(troops[3], tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("InsideContainerTroop")) { newTroop = Instantiate(insideTroop, tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("FastTroop")) { newTroop = Instantiate(troops[1], tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("ParalyzeTroop")) { newTroop = Instantiate(troops[5], tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("SlowTroop")) { newTroop = Instantiate(troops[2], tp.position, troopEntryPoint.rotation); }
            else if (tp.type.Contains("UserTroop")) { newTroop = Instantiate(troops[4], tp.position, troopEntryPoint.rotation); }
            newTroop.rezzed = true;
            ga.rezButtonPressed = true;
            rez_button.interactable = false;

            // clear list
            ga.deadTroops = new List<TroopCopy>();
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
                turretSound.Play();
                // fix the turret in place
                PlayerPrefs.SetInt("turrets_built", PlayerPrefs.GetInt("turrets_built") + 1);
                ga.curr_turret_held.placed = true;
                Vector3 pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                ga.curr_turret_held.placed_pos = Camera.main.ScreenToWorldPoint(pos);
                ga.curr_turret_held.GetComponent<Collider2D>().isTrigger = false;

                // pay for turret
                PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") - ga.turret_costs[int.Parse(ga.curr_turret_held.name[0].ToString())]);

                ga.holding_turret = false;
                ga.curr_turret_held = null;
            }
        }
    }
}
