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

    // troop and turret costs
    public int[] troop_costs;
    public int[] turret_costs;

    //
    public Text timer_text;
    public int gameTimer;
    public float currentGameTime;
    public float gameTimerInterval = 1.0f;
    public GameObject gameOverMenu;

    public Button destroy_button;
    public bool destroySelectButtonPressed;
    public int destroyCost = 5000;
    public int totalDestroySelects = 5;
    public int destroySelectsLeft;

    public Button freeze_button;
    public bool freezeButtonPressed;
    public int freezeCost = 2000;

    public List<TroopCopy> deadTroops;
    public bool speedUpButtonPressed;
    public bool rezButtonPressed;

    public bool userTroopAlive;

    // Use this for initialization
    void Start () {
        holding_turret = false;
        can_place_turret = true;
        curr_turret_held = null;
        gameTimer = 120;
        timer_text.text = gameTimer.ToString();
        deadTroops = new List<TroopCopy>();

        troop_costs = new int[] { 200, 400, 400, 1000, 2000, 1500 };
        turret_costs = new int[] { 500, 1500, 800, 1800, 2500 };

    destroySelectsLeft = totalDestroySelects;
        destroySelectButtonPressed = false;

        speedUpButtonPressed = false;

        userTroopAlive = false;
	}
	
	// Update is called once per frame
	void Update () {
        ap_name_text.text = "Player: " + PlayerPrefs.GetString("attplayername");
        ap_gold_text.text = "Gold: " + PlayerPrefs.GetInt("ap_money");
        ap_score_text.text = "Score: " + PlayerPrefs.GetInt("ap_score");
        ap_troops_sent_text.text = "Troops Sent: " + PlayerPrefs.GetInt("troops_sent");
        ap_troops_killed_text.text = "Troops Killed: " + PlayerPrefs.GetInt("troops_killed");

        dp_name_text.text = "Player: " + PlayerPrefs.GetString("defplayername");
        dp_gold_text.text = "Gold: " + PlayerPrefs.GetInt("dp_money");
        dp_score_text.text = "Score: " + PlayerPrefs.GetInt("dp_score");
        dp_turrets_built_text.text = "Turrets Built: " + PlayerPrefs.GetInt("turrets_built");
        dp_troops_killed_text.text = "Troops Killed: " + PlayerPrefs.GetInt("troops_killed");

        string minutes = ((int)(gameTimer / 60)).ToString();
        string seconds_s = ((int)(gameTimer % 60)).ToString();
        if (seconds_s.Length == 1) { seconds_s = "0" + seconds_s; }
        timer_text.text = minutes + ":" + seconds_s;
        currentGameTime += Time.deltaTime;
        if (currentGameTime >= gameTimerInterval) {
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") + 100);
            PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") + 100);
            gameTimer -= 1;
            currentGameTime = 0.0f;
        }

        if (timer_text.text == "0:00") {
            if (PlayerPrefs.GetInt("ap_score") == PlayerPrefs.GetInt("dp_score")) {
                End("no one");
            }
            if (PlayerPrefs.GetInt("ap_score") < PlayerPrefs.GetInt("dp_score")) {
                End("attacker");
            }
            if (PlayerPrefs.GetInt("ap_score") > PlayerPrefs.GetInt("dp_score")) {
                End("defender");
            }
        }
    }

    void End (string winner) {
		gameOverMenu.SetActive(true);
		Text endGameText = gameOverMenu.GetComponentInChildren<Text> ();
		endGameText.text = winner + " wins";
    }
}
