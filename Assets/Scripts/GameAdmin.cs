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

    //
    public Text timer_text;
    public int gameTimer;
    public float currentGameTime;
    public float gameTimerInterval = 1.0f;
    private bool gameOver;
    public GameObject gameOverMenu;

    public int destroySelectsLeft;

    // Use this for initialization
    void Start () {
        holding_turret = false;
        can_place_turret = true;
        curr_turret_held = null;
        gameOver = false;
        gameTimer = 360;
        timer_text.text = gameTimer.ToString();
        //gameOverText.text = "";

        destroySelectsLeft = 5;
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

        string minutes = ((int)(gameTimer / 60)).ToString();
        int seconds = (int)(gameTimer % 60);
        string seconds_s = ((int)(gameTimer % 60)).ToString();
        if (seconds_s.Length == 1) { seconds_s = "0" + seconds_s; }
        timer_text.text = minutes + ":" + seconds_s;
        currentGameTime += Time.deltaTime;
        if (currentGameTime >= gameTimerInterval) {
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
        //if (PlayerPrefs.GetInt("ap_score") >= 5) {
        //    End("attacker");
        //}

		//if (PlayerPrefs.GetInt("dp_score") >= 5) {
		//	End("defender");
		//}
    }

    void End (string winner) {
        gameOver = true;
		gameOverMenu.SetActive(true);
		Text endGameText = gameOverMenu.GetComponentInChildren<Text> ();
		endGameText.text = winner + " wins";
    }
}
