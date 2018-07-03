using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text text;
    private float t;

	// Use this for initialization
	void Start () {
        t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "" + (int)(Time.time - t) + " sec.";
	}
}
