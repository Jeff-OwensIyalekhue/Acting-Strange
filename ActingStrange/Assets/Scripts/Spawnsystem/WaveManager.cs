using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    //members
    private int waveCount = 0;
    private float time = 0;
    private int enemyCount;
    private int currEnemies;

    private Spellbook spellbook;

    public enum WaveState { RUNNING, PAUSED, FINISHED, STARTING };
    WaveState state;

    // Use this for initialization
    void Start () {
        spellbook = GameObject.GetComponent<Spellbook>();
        setStarting();
	}
	
	// Update is called once per frame
	void Update () {
        if (state.Equals(WaveState.STARTING))
        {
            time += Time.deltaTime;
        }

        if(currEnemies == 0)
        {
            setFinished();
        }

        if (state.Equals(WaveState.RUNNING))
        {
            //TODO: spawn enemies
        }
	}

    public void setStarting()           //state STARTING may be redundant; if, move this to setRunning()
    {
        state = WaveState.STARTING;
        waveCount++;
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
        //TODO: show menu
    }

    int calcEnemies(int waves)
    {
        //TODO: calc enemies to spawn this wave
        return waves;
    }

    public void gameOver()
    {
        //TODO: save waveCount-1 as score;
    }

    public void killedEnemies(int count)
    {
        currEnemies -= count;
    }
}
