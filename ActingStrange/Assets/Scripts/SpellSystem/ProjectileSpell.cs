using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell {

    //members

    //spell attributes
    private float speed;
    private int penetration;

    //base functions
    void Start()
    {
      
    }

    void Update()
    {
     
    }

    //methods
    void cast()
    {
        if (cdRemaining <= 0)
        {
            //find all targets at lane
            WaveManager waveManager = gameObject.GetComponent<WaveManager>();
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Lane_"+ waveManager.getCurrLane().ToString());
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
            GameObject spellInstance = Instantiate(spellObject, transform.position,Quaternion.identity); //add spellobject and rotation(vector strangePosition - target)
            SpellStats instanceStats = spellInstance.AddComponent<SpellStats>();
            instanceStats = stats;
            instanceStats.target = target;

            //reset cd
            cdRemaining = cd;
        }
    }
}
