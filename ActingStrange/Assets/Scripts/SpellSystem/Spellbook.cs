using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour {

    //members
    private int pointsToSpend;
    private Spell[] spellList;  //list of all spells in the game
    private Spell[] spellCache = new Spell[4]; //list of 4 cosen spells
	//base functions
	void Start () {

	}
	
	void Update () {
		
	}

    //methods
    void spendPoint(Spell spell)
    {
        if (spell.getCurrPoints() < spell.getPointsToUnlock() && !spell.isUnlocked())
        {
            pointsToSpend--;
            spell.addCurrPoints(1);
        }
    }

    void returnPoint(Spell spell)
    {
        if (spell.getCurrPoints() > 0)
        {
            spell.addCurrPoints(-1);
            pointsToSpend++;
        }
       
    }

    void commitPoints()
    {
        for(int i = 0; i < spellList.Length; i++)
        {
            Spell spell = spellList[i];
            if(spell.getCurrPoints() == spell.getPointsToUnlock())
            {
                spell.unlock();
                spell.addCurrPoints((-1)* spell.getCurrPoints());
                Debug.Log(spell.getName() +" successfully unlocked.");
                //TODO: popup
                //TODO check if latest spell in cache
            }
        }
    }

    void selectSpell(Spell spell)
    {
        if (spell.isUnlocked())
        {
            spellCache[spell.getSubID()] = spell;
        }
        else
        {
            Debug.Log("Spell not unlocked yet.");
            //TODO: popup
        }
    }

    public Spell[] getSpellCache()
    {
        return spellCache;
    }
}
