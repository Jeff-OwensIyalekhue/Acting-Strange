using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverse : MonoBehaviour {
    public float duration;
	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<WaveManager>().rewind = true;
        StartCoroutine(Reverse());

    }

    IEnumerator Reverse()
    {
        yield return new WaitForSeconds(duration);
        GameObject.FindObjectOfType<WaveManager>().rewind = false;
    }

        // Update is called once per frame
   void Update () {
		
	}
}
