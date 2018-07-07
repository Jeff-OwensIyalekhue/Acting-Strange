﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    //members
    public int waveCount = 0;
    private float time = 0;
    private int enemyCount;
    private int currEnemies;
    private int currLane;   //1 >> left, 2 >> mid, 3 >> right
    [Header("Player Stats")]
    public float health;
    private float currHealth;

    private Spellbook spellbook;

    public enum WaveState { RUNNING, PAUSED, FINISHED, STARTING };
    public WaveState state;

    //UI elements
    [Header("UI Elements")]
    public GameObject inGameOverlay;
    public GameObject clearScreen;
    public Text timeText;
    public Text healthText;
    public Text waveText;
    public Text spellText;
    public Image slot1Image;
    public Image slot2Image;
    public Image slot3Image;
    public Image slot4Image;


    // Use this for initialization
    void Start () {
        spellbook = gameObject.GetComponent<Spellbook>();
        setStarting();
        currLane=1;
        currHealth = health;

	}
	
	// Update is called once per frame
	void Update () {
        if (state.Equals(WaveState.STARTING))
        {
            time += Time.deltaTime;
        }
        timeText.text = "" + (int)time + " sec.";
        healthText.text = "" + (int)currHealth;

        if(currEnemies == 0)
        {
            setFinished();
        }

        if (state.Equals(WaveState.RUNNING))
        {
            //TODO: spawn enemies with tag = "Lane"+currLane.toString();
            if (currHealth <= 0)
            {
                //TODO: ondeath stuff
                GameManager gameManager = FindObjectOfType<GameManager>();
                inGameOverlay.SetActive(false);
                gameManager.LoadLevel(0);

            }
        }
	}

    public void setStarting()           //state STARTING may be redundant; if, move this to setRunning()
    {
        state = WaveState.STARTING;
        waveCount++;
        waveText.text = "" + waveCount;
        enemyCount = calcEnemies(waveCount);
        currEnemies = enemyCount;
    }

    public void setRunning()             
    {
        state = WaveState.RUNNING;
        
        //TODO
    }

    public void setPaused()
    {
        state = WaveState.PAUSED;
        //TODO: show menu
    }

    public void setFinished()
    {
        state = WaveState.FINISHED;
        clearScreen.SetActive(true);

    }

    int calcEnemies(int waves)
    {
        //TODO: calc enemies to spawn this wave
        return waves;
    }

    public void gameOver()
    {
        //TODO: save waveCount-1 as score;
        //GameData.SaveHighscore()
    }

    public void killedEnemies(int count)
    {
        currEnemies -= count;
    }

    public int getCurrLane()
    {
        return currLane;
    }

    public void reduceHealth(float dmg)
    {
        currHealth -= dmg;
    }

    public float getCurrHealth()
    {
        return currHealth;
    }

    public float getTime()
    {
        return time;
    }

    public void spawnEnemy(int lane)
    {
        //TODO: instanciate enemy on given lane(rdm pos)
    }

    public void setSpellText(string text)
    {
        spellText.text = text;
    }

    public void setImage(int slot, Sprite image)
    {
        switch (slot)
        {
            case 0:
                slot1Image.sprite = image;
                break;
            case 1:
                slot2Image.sprite = image;
                break;
            case 2:
                slot3Image.sprite = image;
                break;
            case 3:
                slot4Image.sprite = image;
                break;
            default:
                Debug.Log("imgae slot out of bounds.");
                break;
        }
    }
}
