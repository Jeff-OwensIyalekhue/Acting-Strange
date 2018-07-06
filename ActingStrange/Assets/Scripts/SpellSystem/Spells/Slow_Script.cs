using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Slow_Script : MonoBehaviour {
    private float speed = 3.5f;
	// Use this for initialization
	void Start () {
        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(11f);
        Destroy(gameObject);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lane_1" || other.tag == "Lane_2"||other.tag == "Lane_3")
        {
            Debug.Log("got_Enemy");
            other.GetComponent<NavMeshAgent>().speed = other.GetComponent<NavMeshAgent>().speed*0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            Debug.Log("got_Enemy");
            other.GetComponent<NavMeshAgent>().speed = other.GetComponent<NavMeshAgent>().speed * 2f;
        }
    }
}

