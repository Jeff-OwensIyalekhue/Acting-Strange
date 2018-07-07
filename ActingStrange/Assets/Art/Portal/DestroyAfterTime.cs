using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {

        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
