using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    public Text input;
    public Text placeholder;
    	
	// Update is called once per frame
	public void PlayerNameUpdate () {
        if (!GameData.Instance.currentName.Equals(input.text.ToString()))
        {
            GameData.Instance.currentName = input.text.ToString();
            placeholder.text = GameData.Instance.currentName;
        }
	}

    private void Update()
    {
        if (!GameData.Instance.currentName.Equals(placeholder.text.ToString()))
        {
            placeholder.text = GameData.Instance.currentName;
        }
        //if (Input.GetKeyDown(KeyCode.T))
        //    Debug.Log(GameData.Instance.currentName);
    }
}
