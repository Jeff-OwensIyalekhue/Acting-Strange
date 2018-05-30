using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Awake() function is in here!!!
    #region singleton-like pattern   
    public static MainMenu instance;

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        musicManager = GetComponent<MusicManager>();
    }
    #endregion

    // global Variables; also includes functions to show and hide panels
    #region Vars
    private bool inMainMenu = true;
    private MusicManager musicManager;

    public Animator fadeAnim;
    public AnimationClip fade;

    public AudioMixer mainMixer;
    public int sceneToLoad;

    #region Panels
    public GameObject main_Panel;
    public GameObject pause_Panel;
    public GameObject settings_Panel;

    #region Panelmanagement
    public void ShowMainPanel()
    {
        main_Panel.SetActive(true);
    }
    public void HideMainPanel()
    {
        main_Panel.SetActive(false);
    }

    public void ShowPausePanel()
    {
        pause_Panel.SetActive(true);
    }
    public void HidePausePanel()
    {
        pause_Panel.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        settings_Panel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        if(settings_Panel.activeSelf)
            settings_Panel.SetActive(false);
    }
    #endregion
    #endregion
    #endregion


    void Update()
    {

        if (Input.GetButtonDown("Cancel") && !inMainMenu && !GameData.Instance.isPaused)
        {
            PauseGame();
        }
        else if(Input.GetButtonDown("Cancel") && !inMainMenu && GameData.Instance.isPaused)
        {
            UnpauseGame();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneWasLoaded;
    }

    void SceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        musicManager.PlayLevelMusic();
    }

    // functions sole to the main menu
    #region  Main Menu
    // Start the game
    public void StartGame()
    {
        Cursor.visible = false;
        musicManager.FadeDown(fade.length);
        Invoke("LoadDelayed", fade.length * .5f);
        fadeAnim.SetTrigger("FadeScene");
        inMainMenu = false;
    }

    void LoadDelayed()
    {
        HideMainPanel();
        SceneManager.LoadScene(sceneToLoad);
    }

    // End the game / return to the desktop
    public void EndGame()
    {   
            //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
        #endif

            //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion

    // functions sole to the pause menu
    #region Pause Menu
    public void PauseGame()
    {
        GameData.Instance.isPaused = true;

        Cursor.visible = true;
        ShowPausePanel();
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        GameData.Instance.isPaused = false;

        Cursor.visible = false;
        HidePausePanel();
        Time.timeScale = 1;
    }
    
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        GameData.Instance.isPaused = false;

        musicManager.FadeDown(fade.length);
        Invoke("BackToMenuDelayed", fade.length * .5f);
        fadeAnim.SetTrigger("FadeScene");
        inMainMenu = true;
    }
    void BackToMenuDelayed()
    {
        HidePausePanel();
        SceneManager.LoadScene(0);
        ShowMainPanel();
    }
    #endregion

    // functions to modify game settings like audio etc.
    #region Settings
    // Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
    public void SetMusicLevel(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
        GameData.Instance.musicVolume = musicLvl;
    }

    // Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
    public void SetSfxLevel(float sfxLevel)
    {
        mainMixer.SetFloat("sfxVol", sfxLevel);
        GameData.Instance.sfxVolume = sfxLevel;
    }

    public void OpenSettings()
    {
        if (inMainMenu)
        {
            HideMainPanel();
            ShowSettingsPanel();
        }
        else if(!inMainMenu)
        {
            HidePausePanel();
            ShowSettingsPanel();
        }
    }

    public void CloseSettings()
    {
        if (inMainMenu)
        {
            HideSettingsPanel();
            ShowMainPanel();
        }
        else if (!inMainMenu)
        {
            HideSettingsPanel();
            ShowPausePanel();
        }
    }

    //save settings persistent via GameData
    public void SaveSettings()
    {
        GameData.Instance.SaveSettings();
    }

    public void LoadSettings()
    {
        GameData.Instance.LoadSettings();
    }

    #endregion
}
