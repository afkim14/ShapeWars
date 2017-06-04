using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsRules : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void quit()
    {
        SceneManager.LoadScene(1);
    }

    public void troopInfo()
    {
        SceneManager.LoadScene(5);
    }

    public void turretInfo()
    {
        SceneManager.LoadScene(4);
    }
}
