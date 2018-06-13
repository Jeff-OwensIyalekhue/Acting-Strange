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
    #endregion

    public void SaveSettings()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameSettings.dat");

        SaveDataSettings data = new SaveDataSettings();
        data.musicVolume = musicVolume;
        data.sfxVolume = sfxVolume;

        bF.Serialize(file, data);
        file.Close();
    }

    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/gameSettings.dat"))
        {
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameSettings.dat", FileMode.Open);
            SaveDataSettings data = (SaveDataSettings)bF.Deserialize(file);
            file.Close();

            musicVolume = data.musicVolume;
            sfxVolume = data.sfxVolume;
        }
    }

    #region Highscore
    public int[] highscoreLevel1;
    public int[] highscoreLevel2;
    public int[] highscoreLevel3;

    public string[] nameList1;
    public string[] nameList2;
    public string[] nameList3;
    #endregion

    public void SaveHighscore()
    {
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/highscores.dat");

        SaveDataHighScore data = new SaveDataHighScore();

        data.highscoreLevel1 = highscoreLevel1;
        data.nameList1 = nameList1;

        data.highscoreLevel2 = highscoreLevel2;
        data.nameList2 = nameList2;

        data.highscoreLevel3 = highscoreLevel3;
        data.nameList3 = nameList3;

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
            nameList1 = data.nameList1;

            highscoreLevel2 = data.highscoreLevel2;
            nameList2 = data.nameList2;

            highscoreLevel3 = data.highscoreLevel3;
            nameList3 = data.nameList3;
        }
        else
        {
            highscoreLevel1 =  new int[] { 0, 0, 0};

            nameList1 = new string[] { "default", "default", "default" };

            highscoreLevel2 = new int[] { 0, 0, 0 };
            nameList2 = new string[] { "default", "default", "default" };

            highscoreLevel3 = new int[] { 0, 0, 0 };
            nameList3 = new string[] { "default", "default", "default" };
        }
    }

}

[Serializable]
class SaveDataSettings
{
    public float musicVolume;
    public float sfxVolume;
}

[Serializable]
class SaveDataHighScore
{
    public int[] highscoreLevel1;
    public int[] highscoreLevel2;
    public int[] highscoreLevel3;

    public string[] nameList1;
    public string[] nameList2;
    public string[] nameList3;
}