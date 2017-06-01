using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopCopy {

    public string type;
    public Vector2 position;
    public Vector2 direction;

	public TroopCopy(string t, Vector2 pos, Vector2 dir)
    {
        type = t;
        position = pos;
        direction = dir;
    }
}
