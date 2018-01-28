﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public int step;
    public float totalDeltaTime;
    // Use this for initialization
    void Start () {
        step = 0;
        totalDeltaTime = 0;

    }
	
	// Update is called once per frame
	void Update () {
        totalDeltaTime +=Time.deltaTime;
        if(totalDeltaTime > 1)
        {
            totalDeltaTime = totalDeltaTime - 1;
            step++;
        }
	}

    public int GetStep()
    {
        return step;
    }
}