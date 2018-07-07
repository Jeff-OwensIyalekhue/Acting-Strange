using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public GameObject FindTarget()
   {
        WaveManager waveManager = gameObject.GetComponent<WaveManager>();
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Lane_" + GameObject.FindObjectOfType<WaveManager>().getCurrLane());
        GameObject target = null;
        //select nearest
        float maxdistance = 100000f;

        //findet nächsten enemy und setzt ihn als target
        foreach (GameObject t in targets)
        {
            float distance = Vector3.Distance(t.transform.position, transform.position);

            if (distance <= maxdistance)
            {
                target = t;
                maxdistance = distance;
            }
        }
        if (target == null)
        {
            Debug.Log("No target found!");
        }
        return target;
   }

}
