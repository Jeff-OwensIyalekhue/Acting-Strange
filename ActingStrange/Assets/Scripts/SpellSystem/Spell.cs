using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    //members
    
    public string name;
    public int ID;
    public int upgradeID;
    public int subID; //accepts 0-7
    public int pointsToUnlockNext;
    public int currPoints;
    public bool unlocked = false;

    public GameObject spellObject;         //for projectileSpell the physical projectile, for aoe the physical aoe

    //spell visuals
    public string subtext;
    public Sprite icon;

    //spell attributes          --- may add these to own obj and after casting, put these on spell Object!?
    public float cd;       //cooldown
    public float cdRemaining;

    [System.Serializable]
    public class SpellStats:MonoBehaviour
    {
        public float dmg;
        public float dot;
        public float slow;
        public float duration;
        public GameObject target;
    }
    public SpellStats stats;

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
    void cast()
    {
       
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
        return stats.dmg;
    }

    public float getDot()
    {
        return stats.dot;
    }

    public float getSlow()
    {
        return stats.slow;
    }

    public float getDuration()
    {
        return stats.duration;
    }

}
