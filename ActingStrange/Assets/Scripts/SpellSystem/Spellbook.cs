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
        pointsToSpend--;
        spell.addCurrPoints(1);
    }

    void returnPoint(Spell spell)
    {
        spell.addCurrPoints(-1);
        pointsToSpend++;
    }

    void commitPoints()
    {
        for(int i = 0; i < spellList.Length; i++)
        {
            Spell spell = spellList[i];
            if(spell.getCurrPoints() >= spell.getPointsToUnlock())
            {
                spell.unlock();
                Debug.Log(spell.getName() +" successfully unlocked.");
                //TODO: popup

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
