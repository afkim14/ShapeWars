using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour {

    public bool holding_turret;
    public bool can_place_turret;
    public Turret curr_turret_held;

    // AttackingPlayer Info
    public Text ap_name_text;
    public Text ap_gold_text;
    public Text ap_score_text;
    public Text ap_troops_sent_text;
    public Text ap_troops_killed_text;

    // DefendingPlayer Info
    public Text dp_name_text;
    public Text dp_gold_text;
    public Text dp_score_text;
    public Text dp_turrets_built_text;
    public Text dp_troops_killed_text;

    // Use this for initialization
    void Start () {
        holding_turret = false;
        can_place_turret = true;
        curr_turret_held = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 2);
        }

    }
}
