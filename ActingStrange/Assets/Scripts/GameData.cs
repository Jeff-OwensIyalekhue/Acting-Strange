﻿using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class GameData
{
    #region Instanziierung
    private static GameData instance;

    private GameData()
    {
        if (instance != null)
            return;
        instance = this;
        
    }

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }

            return instance;
        }
    }
    #endregion

    // bool to display the current status of the game (is paused or not)
    public bool isPaused = false;

    #region Settings
    // Volume of SFX and music
    public float musicVolume = 0;
    public float sfxVolume = 0;
    public float voiceVolume = 0;
    #endregion

    public void SaveSettings()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSettings.dat");

        SaveDataSettings data = new SaveDataSettings();
        data.musicVolume = musicVolume;
        data.sfxVolume = sfxVolume;
        data.voiceVolume = voiceVolume;

        bF.Serialize(file, data);
        file.Close();
    }

    public void LoadSettings()
    {
        //Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/gameSettings.dat"))
        {
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSettings.dat", FileMode.Open);
            SaveDataSettings data = (SaveDataSettings)bF.Deserialize(file);
            file.Close();

            musicVolume = data.musicVolume;
            sfxVolume = data.sfxVolume;
            voiceVolume = data.voiceVolume;
        }
    }

    #region Highscore
    public String currentName = "Benedict Cumberbatch";

    public HighScore[] highscoreLevel1 = new HighScore[3];
    #endregion

    public void AddHighScore(int candidatScore)
    {
        //Debug.Log("adding score attempt");
        if(candidatScore > highscoreLevel1[2].score)
        {
            HighScore candidat = new HighScore(currentName, candidatScore);
            if(candidatScore <= highscoreLevel1[1].score)
            {
                highscoreLevel1[2] = candidat;
                SaveHighscore();
                //Debug.Log("add at 3");
            }
            else
            {
                if(candidatScore <= highscoreLevel1[0].score)
                {
                    highscoreLevel1[2] = highscoreLevel1[1];
                    highscoreLevel1[1] = candidat;
                    //Debug.Log("add at 2");
                }
                else
                {
                    highscoreLevel1[2] = highscoreLevel1[1];
                    highscoreLevel1[1] = highscoreLevel1[0];
                    highscoreLevel1[0] = candidat;
                    //Debug.Log("add at 1");
                }
                SaveHighscore();
            }
        }
    }

    public void SaveHighscore()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/highscores.dat");

        SaveDataHighScore data = new SaveDataHighScore();

        data.highscoreLevel1 = highscoreLevel1;

        bF.Serialize(file, data);
        file.Close();
    }

    public void LoadHighscore()
    {
        if (File.Exists(Application.persistentDataPath + "/highscores.dat"))
        {
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscores.dat", FileMode.Open);
            SaveDataHighScore data = (SaveDataHighScore)bF.Deserialize(file);
            file.Close();
            
            highscoreLevel1 = data.highscoreLevel1;
        }
        else
        {
            highscoreLevel1 = new HighScore[] { new HighScore("Benedict Cumberbatch", 0),
                                                new HighScore("Benerec Cumbersnatch", 0),
                                                new HighScore("Fenedict Slumberwitch", 0) };
        }
    }

}

[Serializable]
class SaveDataSettings
{
    public float musicVolume;
    public float sfxVolume;
    public float voiceVolume;
}

[Serializable]
class SaveDataHighScore
{
    public HighScore[] highscoreLevel1 = new HighScore[3];
}

[Serializable]
public class HighScore
{
    public string name;
    public int score;

    public HighScore(string n, int s)
    {
        name = n;
        score = s;
    }
}
