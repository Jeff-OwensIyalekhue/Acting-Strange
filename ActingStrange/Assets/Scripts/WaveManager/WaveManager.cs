using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    //members
    public int waveCount = 5;
    private float time = 0;
    private float spawnTimer = 0;
    private int currLane;   //1 >> left, 2 >> mid, 3 >> right
    public bool rewind;
    [Header("Player Stats")]
    public float health;
    private float currHealth;
    public int scoreFactor = 1000;

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

    [Header("EnemySpawn")]
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public GameObject enemy;
    private int enemyCount;
    private int[] enemiesToSpawn = new int[3];
    private int currEnemies;
    private int spawnedEnemies;

    // Use this for initialization
    void Start () {
        spellbook = gameObject.GetComponent<Spellbook>();
        currLane=2;
        spawnedEnemies = 0;
        setStarting();
    }

    //for spawn testing
    //public GameObject enem1 = null;
    //public GameObject enem2 = null;
    //public GameObject enem3 = null;

    // Update is called once per frame
    void Update () {
        //Debug.Log(state.ToString());
        
        timeText.text = "" + (int)time + " sec.";
        healthText.text = "L:" + (int)currHealth;

        if (state.Equals(WaveState.RUNNING))
        {

            slot1Image.fillAmount = (spellbook.getSpellCache()[0].cd - spellbook.getSpellCache()[0].cdRemaining) / spellbook.getSpellCache()[0].cd;
            slot2Image.fillAmount = (spellbook.getSpellCache()[1].cd - spellbook.getSpellCache()[1].cdRemaining) / spellbook.getSpellCache()[1].cd;
            slot3Image.fillAmount = (spellbook.getSpellCache()[2].cd - spellbook.getSpellCache()[2].cdRemaining) / spellbook.getSpellCache()[2].cd;
            slot4Image.fillAmount = (spellbook.getSpellCache()[3].cd - spellbook.getSpellCache()[3].cdRemaining) / spellbook.getSpellCache()[3].cd;

            if (currEnemies == 0)
            {
                setFinished();
            }

            if (time >= spawnTimer && spawnedEnemies < 13)
            {
                for(int i = 0; i < 3; i++)
                {
                    float r = Random.value;
                    if (enemiesToSpawn[i] > 0 && r > 0.4)
                    {
                        enemiesToSpawn[i]--;
                        spawnedEnemies++;
                        spawnEnemy(i + 1);                        
                    }
                }
                spawnTimer = time + Random.Range(2f, 4f);
            }

            if (currHealth <= 0)
            {
                //TODO: ondeath stuff
                setFinished();
                gameOver();
                GameManager gameManager = FindObjectOfType<GameManager>();
                inGameOverlay.SetActive(false);
                gameManager.LoadLevel(0);

            }
            time += Time.deltaTime;
        }


        //test for enemy spawning
        //for (int i = 0; i < 10000; i++)
        //{
        //    if (i % 30 == 0)
        //    {
        //        Destroy(enem1);
        //        Destroy(enem2);
        //        Destroy(enem3);
        //        enem1 = spawnEnemy(1);
        //        enem2 = spawnEnemy(2);
        //        enem3 = spawnEnemy(3);
        //    }
        //}
    }

    public void setStarting()           //state STARTING may be redundant; if, move this to setRunning()
    {
        state = WaveState.STARTING;
        waveCount++;
        currHealth = health;
        waveText.text = "Scene " + waveCount;
        enemyCount = calcEnemies(waveCount);
        currEnemies = enemyCount;
        time = 0;
        spawnTimer = time + Random.Range(0f, 3f);
        setRunning();
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
        spellbook.addPointToSpend(1);
        clearScreen.SetActive(true);

    }

    int calcEnemies(int waves)
    {
        int enemyCount = (int)( waves * 3 + (Mathf.Pow(2,waves/7)));
        int rdm = Random.Range(0, 3);
        int main = (int)((enemyCount / 3) + Random.Range(0f, enemyCount / 12));
        int other = (enemyCount - main)/2;
        enemyCount = main + 2 * other;
        for (int i = 0; i < 3; i++)
        {
            if(i == rdm)
            {
                enemiesToSpawn[i] = main;
            }
            else
            {
                enemiesToSpawn[i] = other;
            }
        }
        return enemyCount;
    }

    public void gameOver()
    {
        this.GetComponent<PlayRandomAudioClip>().MuteClip();
        GameData.Instance.AddHighScore((int)(((waveCount-1) + ((enemyCount-currEnemies)/(float)enemyCount)) * scoreFactor));
    }

    public void killedEnemies(int count)
    {
        currEnemies -= count;
        spawnedEnemies -= count;
    }

    public int getCurrLane()
    {
        return currLane;
    }
    public void setCurrLane(int x)
    {
        currLane += x;
    }

    public void reduceHealth(float dmg)
    {
        this.GetComponent<PlayRandomAudioClip>().PlayClip();
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

    public GameObject spawnEnemy(int lane)
    {
        GameObject spawn = null;
        switch (lane)
        {
            case 1:
                spawn = Instantiate(enemy, randCircle(spawn1, 3), spawn1.rotation);
                
                break;
            case 2:
                spawn = Instantiate(enemy, randCircle(spawn2, 3), spawn2.rotation);
                break;
            case 3:
                spawn = Instantiate(enemy, randCircle(spawn3, 3), spawn3.rotation);
                break;
            default:
                Debug.Log("Enemy could not be spawned at wave: " + lane);
                break;
        }
        spawn.tag = "Lane_" + lane;
        Debug.Log("Enemie spawned");
        return spawn;
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

    public Vector3 randCircle(Transform center, float maxRadius)
    {
        float radius = Random.RandomRange(0, maxRadius);
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.position.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = center.position.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = center.position.y;
        return pos;
    }
}
