using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class Spell2 : MonoBehaviour
{

    //members

    public string name;
    public int subID; //accepts 0-3 and references the spellcache slot
    public int spellType; //accepts 0-3 and references: 0>>Projectile  1>>AoE 2>>Obstacle
    public int pointsToUnlock1;
    public int pointsToUnlock2;
    public int currPoints;
    public int stage; //0-2

    public GameObject spellObject1;         //for projectileSpell the physical projectile, for aoe the physical aoe
    public GameObject spellObject2;
    public GameObject spellObject3;

    //spell visuals
    public string subtext;
    public string upgradeText1;
    public string upgradeText2;

    public Sprite icon;     //nice to have: 3 icons

    //spell attributes          --- may add these to own obj and after casting, put these on spell Object!?
    public float cd1;       //cooldown
    public float cd2;
    public float cd3;
    public float cdRemaining;

    //Jeff
    public WaveManager wM;

    //base functions
    void Start()
    {
        //TODO
    }

    void Update()
    {
        if (wM.state.Equals(WaveManager.WaveState.RUNNING))
        {
            calcCd();
        }

    }

    //methods
    public void cast()
    {
        if (cdRemaining <= 0)
        {
            GameObject target = gameObject.GetComponent<TargetFinder>().FindTarget();
            GameObject spellInstance;
            GameObject objToInstance = null;
            switch (stage)
            {
                case 0:
                    objToInstance = spellObject1;
                    cdRemaining = cd1;
                    break;
                case 1:
                    objToInstance = spellObject2;
                    cdRemaining = cd2;
                    break;
                case 2:
                    objToInstance = spellObject3;
                    cdRemaining = cd3;
                    break;
                default:
                    Debug.Log("stage of spell not btw. 0 - 2");
                    break;
            }
            switch (spellType)
            {
                case 0:
                    spellInstance = Instantiate(objToInstance, transform.position, Quaternion.identity);
                    break;
                case 1:
                    spellInstance = Instantiate(objToInstance, target.transform.position, Quaternion.identity);
                    break;
                case 2:
                    spellInstance = Instantiate(objToInstance,
                                                      target.transform.position + target.transform.forward * 5,
                                                      Quaternion.Euler(target.transform.forward));
                    break;
                default:
                    Debug.Log("type of spell not btw. 0 - 2");
                    break;
            }
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

    public float getPointsToUnlock1()
    {
        return pointsToUnlock1;
    }

    public float getPointsToUnlock2()
    {
        return pointsToUnlock2;

    }

    public int getCurrPoints()
    {
        return currPoints;
    }

    public void addCurrPoints(int points)
    {
        currPoints += points;
    }

    public string getSubtext()
    {
        return subtext;
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public float getCdRemaining()
    {
        return cdRemaining;
    }

    public int getStage()
    {
        return stage;
    }

    public void setStage(int stage)
    {
        this.stage = stage;
    } 
}
