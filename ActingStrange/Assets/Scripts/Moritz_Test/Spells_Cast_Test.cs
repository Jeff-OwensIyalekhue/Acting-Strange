using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells_Cast_Test : MonoBehaviour {
    public GestureController gc;
    public GameObject playerAvatar;

    public Spellbook spellbook;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("spell 0!!!");
            spellbook.spellCache[0].cast();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("spell 0!!!");
            spellbook.spellCache[2].cast();

        }
    }
}
