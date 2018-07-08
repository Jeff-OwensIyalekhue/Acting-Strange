using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour {

    Transform target;
    GameObject[] targets;
    WaveManager waveManager;

    string currentSearchedTag;

    // Use this for initialization
    void Start () {
        waveManager = this.GetComponent<WaveManager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            FindTarget();
            
	}

   public Transform FindTarget()
   {
        currentSearchedTag = "Lane_" + waveManager.getCurrLane();
        Debug.Log(currentSearchedTag);
        targets = GameObject.FindGameObjectsWithTag(currentSearchedTag);
        //select nearest
        float maxdistance = 100000f;

        //findet nächsten enemy und setzt ihn als target
        foreach (GameObject t in targets)
        {
            float distance = Vector3.Distance(t.transform.position, transform.position);

            if (distance <= maxdistance)
            {
                target = t.transform;
                maxdistance = distance;
            }
        }
        if (target == null)
        {
            switch (waveManager.getCurrLane())
            {
                case 1:
                    target = waveManager.spawn1;
                    break;
                case 2:
                    target = waveManager.spawn2;
                    break;
                case 3:
                    target = waveManager.spawn3;
                    break;
                default:
                    break;
            }
            Debug.Log("No target found!");
        }
        return target;
   }

}
