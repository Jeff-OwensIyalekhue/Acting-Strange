using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MissileSpell : MonoBehaviour {

    //members

    //spell attributes
    private float speed;
    private int penetration;
    private List<GameObject[]> targets=new List<GameObject[]>();
    private Transform targetpos;
    //die missiles die initiert werden sollen
    public GameObject missile;
    //legt fest welche lane wir gerade sind, sollte beim aufrufen des scripts gesetzt werden
    public string lane;

    public bool simple;

    //base functions
    void Start()
    {
        //sollte vllt in cast() methode übertragen werden?!
        int currlane = FindObjectOfType<WaveManager>().getCurrLane();
        //setzt variablen
        //überprüft auf welcher lane wir sind oder ob wir alle lanes angreifen
        if (simple)
        {
            switch (currlane)//FindObjectOfType<WaveManager>().getCurrLane())
            {
                case 1:
                    targets.Add(GameObject.FindGameObjectsWithTag("Lane_1"));
                    break;
                case 2:
                    targets.Add(GameObject.FindGameObjectsWithTag("Lane_2"));
                    break;
                case 3:
                    targets.Add(GameObject.FindGameObjectsWithTag("Lane_3"));
                    break;
                default:
                    Debug.Log("Nix");
                    break;
            }
        }
        else
        {
            targets.Add(GameObject.FindGameObjectsWithTag("Lane_1"));
            targets.Add(GameObject.FindGameObjectsWithTag("Lane_2"));
            targets.Add(GameObject.FindGameObjectsWithTag("Lane_3"));
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
