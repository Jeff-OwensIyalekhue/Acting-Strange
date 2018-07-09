using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane_0 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Lane_1") || other.tag.Equals("Lane_2") || other.tag.Equals("Lane_3"))
        {
            other.GetComponent<Enemy>().lane_0 = true;
        }
    }
}
