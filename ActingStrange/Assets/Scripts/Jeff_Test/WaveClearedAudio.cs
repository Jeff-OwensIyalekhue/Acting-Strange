using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveClearedAudio : MonoBehaviour {

    public GameObject screen;
    bool played = false;
	
	// Update is called once per frame
	void Update () {
		if(screen.activeSelf && !played)
        {
            played = true;
            GetComponent<PlayRandomAudioClip>().PlayClip();
        }
        if (!screen.activeSelf)
            played = false;
	}
}
