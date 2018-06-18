using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    //members
    private string name;
    private int subID; //accepts 0-3
    private int pointsToUnlock;
    private int currPoints;
    private bool unlocked = false;

    //spell attributes
    private float cd;
    private float cdRemaining;
    private float dmg;
    private float dot;
    private float slow;
    private float duration;

    //spell visuals
    //TODO

    //base functions
    void Start () {
		//TODO
	}
	
	void Update () {

        //TODO
        calcCd();   //add: if(ingame)
	}

    //methods
    void cast()
    {
        if (cdRemaining <= 0)
        {
            //TODO
            cdRemaining = cd;
        }
    }

    void calcCd()
    {
        if (cdRemaining > 0)
        {
            cdRemaining -= Time.deltaTime;

        }
    }
    
    //getter/setter
    public string getName()
    {
        return name;
    }

    public int getSubID()
    {
        return subID;
    }

    public float getPointsToUnlock()
    {
        return pointsToUnlock;
    }

    public float getCurrPoints()
    {
        return currPoints;
    }

    public void addCurrPoints(int points)
    {
        currPoints += points;
    }

    public bool isUnlocked()
    {
        return unlocked;
    }

    public void unlock()
    {
        unlocked = true;
    }

    public float getCd()
    {
        return cd;
    }

    public float getCdRemaining()
    {
        return cdRemaining;
    }

    float getDmg()
    {
        return dmg;
    }

    public float getDot()
    {
        return dot;
    }

    public float getSlow()
    {
        return slow;
    }

    public float getDuration()
    {
        return duration;
    }



}
