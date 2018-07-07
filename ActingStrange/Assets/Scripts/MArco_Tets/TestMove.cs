using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {


    public WaveManager wm;
	// Use this for initialization
	void Start () {
        wm = GameObject.FindObjectOfType<WaveManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward*2f);

        if (transform.position.z < -120.0)
        {
            wm.killedEnemies(1);
            wm.reduceHealth(1);
            Destroy(gameObject);
        }
	}
}
