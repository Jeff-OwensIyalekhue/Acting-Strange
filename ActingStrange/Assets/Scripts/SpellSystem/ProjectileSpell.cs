using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell {

    //members

    //spell attributes
    private float speed;
    private int penetration;
    private GameObject[] targets;
    private Transform targetpos;
    //legt fest welche lane wir gerade sind, sollte beim aufrufen des scripts gesetzt werden
    public string lane;
    //base functions
    void Start()
    {
        //sollte vllt in cast() methode übertragen werden?!

        //setzt variablen
        //überprüft auf welcher lane wir sind
        switch (lane)
        {
            case "Lane_1":
                targets = GameObject.FindGameObjectsWithTag("Lane_1");
                break;
            case "Lane_2":
                targets = GameObject.FindGameObjectsWithTag("Lane_2");
                break;
            case "Lane_3":
                targets = GameObject.FindGameObjectsWithTag("Lane_3");
                break;
            default:
                break;
        }
        
        //dummy distance, ganz weit weg gesetzt...
        float maxdistance = 100000000f;

        //findet nächsten enemy und setzt ihn als target
        foreach (GameObject t in targets)
        {
            float distance = Vector3.Distance(t.transform.position, transform.position);
            
            if (distance <= maxdistance)
            {
                targetpos = t.transform;
                maxdistance = distance;
            }
        }

        //test speed, sollte auch gesetzt werden... 

        speed = 0.1f;
    }

    void Update()
    {
        //updatet position
        transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed);
        //vllt mit look at besser..
        transform.LookAt(targetpos);
    }

    //methods
    void cast()
    {
        //particle effekt evtl auslösen
    }
}
