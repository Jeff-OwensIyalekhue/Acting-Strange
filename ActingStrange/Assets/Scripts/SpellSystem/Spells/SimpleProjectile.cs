using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : Spell {

    public Transform target;
    public float damage;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {

            other.GetComponent<Enemy>().health -= damage;
            DestroyObject(gameObject);
        }
    }
}
