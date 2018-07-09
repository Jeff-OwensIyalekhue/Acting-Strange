using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public Image black;
    public GameObject scroll;
    public float speed;
    public int end = 1100;

    bool roll = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(roll)
            scroll.transform.position = Vector3.MoveTowards(scroll.transform.position, scroll.transform.position + Vector3.up * 2, speed);
        if (scroll.transform.position.y >= end)
        {
            roll = false;
            black.CrossFadeAlpha(0f, 2.8f, false);
            StartCoroutine(Fade());
        }
    }

    public void ShowCredits()
    {
        black.CrossFadeAlpha(255f, 3f, false);
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        yield return new WaitForSeconds(3f);
        roll = true;
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
