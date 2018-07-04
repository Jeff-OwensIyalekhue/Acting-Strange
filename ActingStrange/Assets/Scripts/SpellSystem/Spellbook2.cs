using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook2 : MonoBehaviour {

    //members
    public int pointsToSpend;

    public Spell2 selectedSpell;
    private WaveManager waveManager;

    public Spell2[] spellBook = new Spell2[8];   // list of spells shown in menu
    public Spell2[] spellCache = new Spell2[4]; //list of 4 cosen spells

    //Jeff
    int selectedID;

    //base functions
    void Start() {
        waveManager = gameObject.GetComponent<WaveManager>();
        for (int i = 0; i < spellCache.Length; i++)       //fill spellcache
        {
            spellCache[i] = spellBook[i * 2];
        }
    }

    void Update() {

    }

    //methods
    public void selectSpell(int id)
    {
        selectedID = id;
        selectedSpell = spellBook[id];
        string text = selectedSpell.subtext+"\n" + "\n";
        switch (selectedSpell.getStage())
        {
            case 0:
                text += "Upgrade: " + selectedSpell.upgradeText1+"\n Points to unlock: " + selectedSpell.currPoints + " / "+ selectedSpell.getPointsToUnlock1() + " [" + pointsToSpend + "]";
                break;
            case 1:
                text += "Upgrade: " + selectedSpell.upgradeText2+"\n Points to unlock: " + selectedSpell.currPoints + " / " + + selectedSpell.getPointsToUnlock2() + " ["+ pointsToSpend+"]";
                break;
            case 2:
                text += "Spell already fully upgraded.";
                break;
            default:
                Debug.Log("spell state ouft of range.");
                break;
        }
        waveManager.setSpellText(text);
    }

    public void chooseSpell()
    {
        if (selectedSpell == null)
            return;
        spellCache[selectedSpell.getSubID()] = selectedSpell;
        waveManager.setImage(selectedSpell.getSubID(), selectedSpell.icon);
    }

    public void spendPoint()
    {
        if (selectedSpell != null && pointsToSpend > 0) { 
            switch (selectedSpell.getStage())
            {
                case 0:
                    if (selectedSpell.getCurrPoints() < selectedSpell.getPointsToUnlock1())
                    {
                        pointsToSpend--;
                        selectedSpell.addCurrPoints(1);
                        selectSpell(selectedID);//fucking bad work around to update the ui...  sooooooorry
                    }
                    break;
                case 1:
                    if (selectedSpell.getCurrPoints() < selectedSpell.getPointsToUnlock2())
                    {
                        pointsToSpend--;
                        selectedSpell.addCurrPoints(1);
                        selectSpell(selectedID);//fucking bad work around to update the ui...  sooooooorry
                    }
                    break;
                case 2:
                    Debug.Log("Point could not be spend, Spell is at max level.");
                    break;
                default:
                    Debug.Log("level of spell not in range of 0 - 2.");
                    break;
            }
        }
        else
        {
            Debug.Log("No spell selected.");
        }
    }

    public void returnPoint()
    {
        if (selectedSpell != null)
        {
            if (selectedSpell.getCurrPoints() > 0)
            {
                selectedSpell.addCurrPoints(-1);
                pointsToSpend++;
                selectSpell(selectedID);//fucking bad work around to update the ui...  sooooooorry
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

    public void commitPoints()
    {
        for (int i = 0; i < spellBook.Length; i++)
        {
            Spell2 spell = spellBook[i];
            if (spell.getCurrPoints() == spell.getPointsToUnlock1() && spell.getStage() == 0)
            {
                spell.setStage(1);
                spell.addCurrPoints((-1) * spell.getCurrPoints());
                selectSpell(selectedID);//fucking bad work around to update the ui...  sooooooorry
                Debug.Log(spell.getName() + " successfully upgraded.");
                //TODO: popup
            }else if (spell.getCurrPoints() == spell.getPointsToUnlock2() && spell.getStage() == 1)
            {
                spell.setStage(2);
                spell.addCurrPoints((-1) * spell.getCurrPoints());
                selectSpell(selectedID);//fucking bad work around to update the ui...  sooooooorry
                Debug.Log(spell.getName() + " successfully upgraded.");
                //TODO: popup
            }
            else
            {
                Debug.Log("stage of spell not btw. 0 - 2");
            }
        }
    }

    public Spell2[] getSpellCache()
    {
        return spellCache;
    }
}
