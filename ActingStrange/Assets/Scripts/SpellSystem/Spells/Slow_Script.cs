using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Slow_Script : MonoBehaviour {
    public float slowFactor= 0.5f;
    public float lifeSpan = 11f;
	// Use this for initialization
	void Start () {
        StartCoroutine(Die());

    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeSpan);
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
            other.GetComponent<NavMeshAgent>().speed = other.GetComponent<NavMeshAgent>().speed * slowFactor;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            Debug.Log("got_Enemy");
            other.GetComponent<NavMeshAgent>().speed = other.GetComponent<NavMeshAgent>().speed / slowFactor;
        }
    }
}

