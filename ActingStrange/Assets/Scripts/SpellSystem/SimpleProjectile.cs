using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Spell {

    public Transform target;
    public float speed=0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        //vllt mit look at besser..
        transform.LookAt(target);
    }
}
