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

    private GameObject spellObject;         //for projectileSpell the physical projectile, for aoe the physical aoe

    //spell visuals
    private string subtext;
    private Sprite icon;

    //spell attributes          --- may add these to own obj and after casting, put these on spell Object!?
    protected float cd;       //cooldown
    protected float cdRemaining;
    private float dmg;  
    private float dot;      //damageOverTime
    private float slow;     //btw 0 & 1
    private float duration;

    //base functions
    void Start () {
		//TODO
	}
	
	void Update () {

        if (gameObject.GetComponent<WaveManager>().state.Equals(WaveManager.WaveState.RUNNING))
        {
            calcCd();
        }

	}

    //methods
    void cast(Transform position)
    {
        if (cdRemaining <= 0)
        {
            //TODO: find target
            Instantiate(spellObject, position); //add spellobject and rotation(vector strangePosition - target)
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

    public float getDmg()
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
