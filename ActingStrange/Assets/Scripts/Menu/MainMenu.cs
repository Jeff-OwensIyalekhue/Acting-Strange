using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public MusicManager musicManager;

    public Text highscore1;
    public Text highscore2;
    public Text highscore3;

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadSettings();
        GameData.Instance.LoadHighscore();
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
        SetMusicLevel(GameData.Instance.musicVolume);
        SetSFXLevel(GameData.Instance.sfxVolume);

        highscore1.text = GameData.Instance.nameList1[0] + ": " + GameData.Instance.highscoreLevel1[0] + "\n"
                            + GameData.Instance.nameList1[1] + ": " + GameData.Instance.highscoreLevel1[1] + "\n"
                            + GameData.Instance.nameList1[2] + ": " + GameData.Instance.highscoreLevel1[2] + "\n";

        highscore2.text = GameData.Instance.nameList2[0] + ": " + GameData.Instance.highscoreLevel2[0] + "\n"
                            + GameData.Instance.nameList2[1] + ": " + GameData.Instance.highscoreLevel2[1] + "\n"
                            + GameData.Instance.nameList2[2] + ": " + GameData.Instance.highscoreLevel2[2] + "\n";

        highscore3.text = GameData.Instance.nameList3[0] + ": " + GameData.Instance.highscoreLevel3[0] + "\n"
                            + GameData.Instance.nameList3[1] + ": " + GameData.Instance.highscoreLevel3[1] + "\n"
                            + GameData.Instance.nameList3[2] + ": " + GameData.Instance.highscoreLevel3[2] + "\n";
    }

    public void StartGame(int x)
    {
        gameManager.LoadLevel(x);
    }

    public void EndGame()
    {
        GameData.Instance.SaveHighscore();
        gameManager.EndGame();
    }

    public void Pause()
    {
        GameData.Instance.isPaused = !GameData.Instance.isPaused;
    }

    public void SetSlider()
    {
        musicSlider.value = GameData.Instance.musicVolume;
        sfxSlider.value = GameData.Instance.sfxVolume;
    }
    public void SetMusicLevel(float x)
    {
        musicManager.SetMusicLevel(x);
    }
    public void SetSFXLevel(float x)
    {
        musicManager.SetSfxLevel(x);
    }

    public void SaveSettings()
    {
        GameData.Instance.SaveSettings();
    }
    public void LoadSettings()
    {
        GameData.Instance.LoadSettings();
    }

}
