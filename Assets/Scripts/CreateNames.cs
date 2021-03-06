﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateNames : MonoBehaviour {

    public InputField attplayer;
    public InputField defplayer;
    public Text info;

    // Use this for initialization
    void Start () {
        info.text = "";
        attplayer.text = PlayerPrefs.GetString("tempattplayername");
        defplayer.text = PlayerPrefs.GetString("tempdefplayername");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ControlsRules()
    {
        PlayerPrefs.SetString("tempattplayername", attplayer.text);
        PlayerPrefs.SetString("tempdefplayername", defplayer.text);
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        bool done = true;
        if (attplayer.text != "" && defplayer.text != "") {
            if (attplayer.text.Contains(" ") || defplayer.text.Contains(" "))
            {
                info.text = "Please remove spaces in the player names.";
                done = false;
            }

            int max_name_length = 7;
            if (attplayer.text.Length > max_name_length || defplayer.text.Length > max_name_length)
            {
                info.text = "Each name should have up to 7 characters.";
                done = false;
            }
        } else
        {
            info.text = "Please fill in both names.";
            done = false;
        }

        if (done)
        {
            PlayerPrefs.SetString("attplayername", attplayer.text);
            PlayerPrefs.SetString("defplayername", defplayer.text);
            SceneManager.LoadScene(3);
        }
    }
}
