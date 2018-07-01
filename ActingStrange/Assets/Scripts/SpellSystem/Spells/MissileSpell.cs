using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MissileSpell : Spell {

    //members

    //spell attributes
    private float speed;
    private int penetration;
    private List<GameObject[]> targets=new List<GameObject[]>();
    private Transform targetpos;
    //die missiles die initiert werden sollen
    public GameObject missile;
    //falls enum nicht funktioniert mit zugriff geht natürlich auch strings
    enum Lanes{
        lane1,
        lane2,
        lane3,
        all
    }
    Lanes choice;
    //legt fest welche lane wir gerade sind, sollte beim aufrufen des scripts gesetzt werden
    public string lane;
    //base functions
    void Start()
    {
        //sollte vllt in cast() methode übertragen werden?!

        //setzt variablen
        //überprüft auf welcher lane wir sind oder ob wir alle lanes angreifen
        switch (choice)
        {
            case Lanes.lane1:
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_1"));
                break;
            case Lanes.lane2:
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_2"));
                break;
            case Lanes.lane3:
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_3"));
                break;
            case Lanes.all:
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_1"));
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_2"));
                targets.Add(GameObject.FindGameObjectsWithTag("Lane_3"));
                break;
            default:
                Debug.Log("Nix");
                break;
        }

        //findet nächsten enemy und setzt ihn als target
        foreach (GameObject[] t in targets)
        {
            foreach (GameObject target in t) {
                Debug.Log("instantiate");
                        GameObject prefab = Instantiate(missile, transform);
                        prefab.GetComponent<SimpleProjectile>().target=target.transform;
                    }
        }

        //test speed, sollte auch gesetzt werden... 

        speed = 0.1f;
    }

    void Update()
    {
        /*
        //updatet position
        transform.position = Vector3.MoveTowards(transform.position, targetpos.position, speed);
        //vllt mit look at besser..
        transform.LookAt(targetpos);
        */
    }

    //methods
    void cast()
    {
        //particle effekt evtl auslösen
    }
}
