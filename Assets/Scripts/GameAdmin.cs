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
        ap_name_text.text = "Junwon";
        ap_gold_text.text = "Gold: " + PlayerPrefs.GetInt("ap_money");
        ap_score_text.text = "Score: " + PlayerPrefs.GetInt("ap_score");
        ap_troops_sent_text.text = "Troops Sent: " + PlayerPrefs.GetInt("troops_sent");
        ap_troops_killed_text.text = "Troops Killed: " + PlayerPrefs.GetInt("troops_killed");

        dp_name_text.text = "Austin";
        dp_gold_text.text = "Gold: " + PlayerPrefs.GetInt("dp_money");
        dp_score_text.text = "Score: " + PlayerPrefs.GetInt("dp_score");
        dp_turrets_built_text.text = "Turrets Built: " + PlayerPrefs.GetInt("turrets_built");
        dp_troops_killed_text.text = "Troops Killed: " + PlayerPrefs.GetInt("troops_killed");
    }
}
