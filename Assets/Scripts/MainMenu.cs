using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("ap_score", 0);
        PlayerPrefs.SetInt("ap_money", 0);
        PlayerPrefs.SetInt("dp_score", 0);
        PlayerPrefs.SetInt("dp_money", 0);
        PlayerPrefs.SetInt("turrets_built", 0);
        PlayerPrefs.SetInt("troops_sent", 0);
        PlayerPrefs.SetInt("troops_killed", 0);
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
