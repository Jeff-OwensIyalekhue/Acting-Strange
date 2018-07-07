using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    public float damage;
    bool coroutineStarted;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    IEnumerator DoDamage(Collider other)
    {
        
        while (coroutineStarted)
        {
            if (other.tag == "PlayerAllies")
            {

                other.GetComponent<PlayerAlliesHealthScript>().health -= damage;
            }
            if (other.tag == "Player")
            {

                other.GetComponent<WaveManager>().health -= damage;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerAllies")
        {
            coroutineStarted = true;
            StartCoroutine(DoDamage(other));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerAllies")
        {
            coroutineStarted = false;

        }
    }
}
