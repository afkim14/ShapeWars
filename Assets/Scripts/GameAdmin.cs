using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdmin : MonoBehaviour {

    public bool holding_turret;
    public bool can_place_turret;
    public Turret curr_turret_held;

	// Use this for initialization
	void Start () {
        holding_turret = false;
        can_place_turret = true;
        curr_turret_held = null;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
