﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Vars
    public static GameManager instance;
    [Header("FadeInOut")]
    public Animator fadeAnim;
    public AnimationClip fade;
    [Header("Loading Screen")]
    public Slider loadingBar;
    public Text loadingText;
    public GameObject loadingBarObj;
    [Header("Voice")]
    AudioSource audioSource;
    [Header("Intro")]
    public AudioClip[] introClips;
    [Header("Outro")]
    public AudioClip[] outroClips;

    private MusicManager musicManager;
    private int sceneToLoad = 0;
    #endregion

    // pseudo singleton
    void Awake () {
        if (instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        musicManager = GetComponentInChildren<MusicManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && audioSource.isPlaying)
        {
            audioSource.Pause();
            StopAllCoroutines();
            SceneManager.LoadScene(sceneToLoad);
            fadeAnim.SetTrigger("FadeOut");
        }
    }

    // Start a level
    public void LoadLevel(int x)
    {
        sceneToLoad = x;
        // fades the music down regarding the lenght of the fade to black animation (fadeIn)
        musicManager.FadeDown(fade.length);
        // plays intros/outros
        if(x != 0)
        {
            int s = Random.Range(0, introClips.Length);
            audioSource.clip = introClips[s];
            audioSource.Play();
        }
        else
        {
            int s = Random.Range(0, outroClips.Length);
            audioSource.clip = outroClips[s];
            audioSource.Play();
        }
        // triggers  the fade to black animation 
        fadeAnim.SetTrigger("FadeIn");
        // coroutinte so the scene starts loading after the screen faded to black
        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        //yield return new WaitForSeconds(fade.length);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        loadingBarObj.SetActive(true);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / .9f);
            loadingBar.value = progress;
            loadingText.text = ((int)(progress * 100)) + "%";
            yield return null;
        }
        loadingBarObj.SetActive(false);
        loadingText.text = "";
        fadeAnim.SetTrigger("FadeOut");
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
}
