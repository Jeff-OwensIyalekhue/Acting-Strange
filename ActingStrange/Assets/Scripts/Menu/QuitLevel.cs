using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevel : MonoBehaviour {

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        while (gameManager.Equals(null))
            gameManager = FindObjectOfType<GameManager>();
    }

    public void Quit()
    {
        gameManager.LoadLevel(0);
    }
}
