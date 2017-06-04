using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private bool paused;
    public GameObject PauseUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused; // not setting it to just true because if we press esc again, should quit

        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1; // default x1 speed
        }

    }

    public void ResumeGame()
    {
        paused = false;
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("ap_money", 0);
        PlayerPrefs.SetInt("dp_money", 0);
        PlayerPrefs.SetInt("turrets_built", 0);
        PlayerPrefs.SetInt("troops_sent", 0);
        PlayerPrefs.SetInt("troops_killed", 0);
        PlayerPrefs.SetInt("homeLivesLeft", 30);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
