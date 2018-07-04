using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour {

    //members
    public int pointsToSpend;

    private GameObject selectedSpell;

    public GameObject[] spellList;  //list of all spells in the game
    public GameObject[] spellBook = new GameObject[8];   // list of spells shown in menu
    public GameObject[] spellCache = new GameObject[4]; //list of 4 cosen spells

    //base functions
    void Start() {
        for(int i = 0; i < spellBook.Length; i++)       //fill spellbook
        {
            spellBook[i] = spellList[i * 3];
        }
        for (int i = 0; i < spellCache.Length; i++)       //fill spellcache
        {
            spellCache[i] = spellBook[i * 2];
        }
    }

    void Update() {

    }

    //methods
    void selectSpell(int id)
    {
        selectedSpell = spellBook[id];
        //show buttons and subtext
    }
    void spendPoint()
    {
        if (selectedSpell != null) { 
            if (selectedSpell.GetComponent<Spell>().getCurrPoints() < selectedSpell.GetComponent<Spell>().getPointsToUnlockNext())
            {
                pointsToSpend--;
                selectedSpell.GetComponent<Spell>().addCurrPoints(1);
            }
            else
            {
                Debug.Log("Point could not be spend. Already enough points.");
            }
        }
        else
        {
            Debug.Log("No spell selected.");
        }
    }

    void returnPoint(Spell spell)
    {
        if (selectedSpell != null)
        {
            if (spell.getCurrPoints() > 0)
            {
                spell.addCurrPoints(-1);
                pointsToSpend++;
            }
            else
            {
                Debug.Log("No points to return");
            }
        }
        else
        {
            Debug.Log("No spell selected.");
        }
    }

    void commitPoints()
    {
        for (int i = 0; i < spellBook.Length; i++)
        {
            GameObject spell = spellBook[i];
            Spell spellScript = spell.GetComponent<Spell>();
            if (spellScript.getCurrPoints() == spellScript.getPointsToUnlockNext())
            {
                getNextSpell(spell).GetComponent<Spell>().unlock();
                spellScript.addCurrPoints((-1) * spellScript.getCurrPoints());
                spellBook[i] = getNextSpell(spell);
                for(int j = 0; j < spellCache.Length; j++)
                {
                    if (spellCache[j] == spell)
                    {
                        spellCache[j] = getNextSpell(spell);
                    }
                }
                Debug.Log(spellScript.getName() + " successfully unlocked.");
                //TODO: popup
                //TODO check if latest spell in cache
            }
        }
    }

    public GameObject[] getSpellCache()
    {
        return spellCache;
    }

    public GameObject getNextSpell(GameObject spell)
    {
        if (spell.GetComponent<Spell>().getUpgradeID() != 0)
        {
            return spellList[spell.GetComponent<Spell>().getUpgradeID()];
        }
        else
        {
            return null;
        }
    }
}
