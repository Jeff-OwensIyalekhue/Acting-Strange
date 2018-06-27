using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    //members
    private string name;
    private int ID;
    private int upgradeID;
    private int subID; //accepts 0-7
    private int pointsToUnlockNext;
    private int currPoints;
    private bool unlocked = false;
    private string subtext;
    private Sprite icon;

    //spell attributes
    private float cd;       //cooldown
    private float cdRemaining;
    private float dmg;  
    private float dot;      //damageOverTime
    private float slow;     //btw 0 & 1
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

    public int getID()
    {
        return ID;
    }

    public int getSubID()
    {
        return subID;
    }

    public int getUpgradeID()
    {
        return upgradeID;
    }

    public float getPointsToUnlockNext()
    {
        return pointsToUnlockNext;
    }

    public int getCurrPoints()
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

    public string getSubtext()
    {
        return subtext;
    }

    public Sprite getIcon()
    {
        return icon;
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
