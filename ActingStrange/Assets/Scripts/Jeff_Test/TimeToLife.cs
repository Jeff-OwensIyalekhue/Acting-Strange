using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLife : MonoBehaviour {

    public float lifeSpan;
    float birthTime;

	// Use this for initialization
	void Start () {
        birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= (birthTime + lifeSpan))
            Destroy(this.gameObject);
	}
}
