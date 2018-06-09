using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public MusicManager musicManager;

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        LoadSettings();
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void StartGame(int x)
    {
        gameManager.LoadLevel(x);
    }

    public void EndGame()
    {
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
