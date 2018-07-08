using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour {
    Transform target;
    public float speed;
    public float damage;
	// Use this for initialization
	void Start () {
        int lane = GameObject.FindObjectOfType<WaveManager>().getCurrLane();
        target = GameObject.Find("Spawn (" + lane + ")").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        //vllt mit look at besser..
        
        transform.LookAt(target);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            other.GetComponent<Enemy>().health -= damage;
        }
    }
}
