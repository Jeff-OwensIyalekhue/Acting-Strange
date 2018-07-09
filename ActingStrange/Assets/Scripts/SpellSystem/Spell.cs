using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
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
    public float cd;       //cooldown
    public float cd2;
    public float cd3;
    public float cdRemaining;

    //Jeff
    public WaveManager wM;
    TargetFinder targetFinder;

    //base functions
    void Start()
    {
        //TODO
        targetFinder = FindObjectOfType<TargetFinder>();
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
            Transform target = targetFinder.FindTarget();
            GameObject spellInstance;
            GameObject objToInstance = null;
            switch (stage)
            {
                case 0:
                    objToInstance = spellObject1;
                    break;
                case 1:
                    objToInstance = spellObject2;
                    break;
                case 2:
                    objToInstance = spellObject3;
                    break;
                default:
                    Debug.Log("stage of spell not btw. 0 - 2");
                    break;
            }
            cdRemaining = cd;
            switch (spellType)
            {
                case 0:
                    spellInstance = Instantiate(objToInstance, transform.position, Quaternion.identity);
                    target.transform.position += Vector3.up * 1.5f;
                    spellInstance.GetComponent<SimpleProjectile>().target = target.transform;
                    //Debug.Log("SpellType 1 castet");
                    break;
                case 1:
                    spellInstance = Instantiate(objToInstance, target.transform.position, Quaternion.identity);
                    break;
                case 2:
                    spellInstance = Instantiate(objToInstance,
                                                      target.transform.position + target.transform.forward * 5,
                                                      Quaternion.Euler(target.transform.forward));
                    break;
                case 3:
                    //shockwave & burst
                    spellInstance = Instantiate(objToInstance, transform.position + Vector3.up*1.5f + transform.forward*2f, Quaternion.identity);
                    break;
                case 4: //for obstacle
                    spellInstance = Instantiate(objToInstance, target.transform.position + target.transform.forward * 2 + target.transform.up * 2, Quaternion.identity);
                    break;
                default:
                    Debug.Log("type of spell not btw. 0 - 3");
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
