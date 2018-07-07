using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            Destroy(other.gameObject);
        }
    }
}
