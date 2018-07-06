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
    public Slider voiceSlider;

    private void Start()
    {
        LoadSettings();
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
        GameData.Instance.LoadHighscore();
        SetMusicLevel(GameData.Instance.musicVolume);
        SetSFXLevel(GameData.Instance.sfxVolume);

        highscore1.text =  "Best Take\n" + GameData.Instance.highscoreLevel1[0].name + "\n" + GameData.Instance.highscoreLevel1[0].score;

        highscore2.text = "Second Choice\n" + GameData.Instance.highscoreLevel1[1].name + "\n" + GameData.Instance.highscoreLevel1[1].score;

        highscore3.text = "Third Choice\n" + GameData.Instance.highscoreLevel1[2].name + "\n" + GameData.Instance.highscoreLevel1[2].score;
    }

    private void Update()
    {
        while (gameManager.Equals(null))
            gameManager = FindObjectOfType<GameManager>();
        while (musicManager.Equals(null))
            musicManager = FindObjectOfType<MusicManager>();
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
        voiceSlider.value = GameData.Instance.voiceVolume;
    }
    public void SetMusicLevel(float x)
    {
        musicManager.SetMusicLevel(x);
    }
    public void SetSFXLevel(float x)
    {
        musicManager.SetSfxLevel(x);
    }
    public void SetVoiceLevel(float x)
    {
        musicManager.SetVoiceLevel(x);
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
