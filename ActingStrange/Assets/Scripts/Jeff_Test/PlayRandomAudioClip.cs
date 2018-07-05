using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomAudioClip : MonoBehaviour {

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public GameManager gameManager;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = this.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        while (gameManager.Equals(null))
            gameManager = FindObjectOfType<GameManager>();
    }

    public void PlayClip()
    {
        if (!audioSource.isPlaying)
        {
            int x = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[x];
            audioSource.Play();

        }
    }

    public void PlayClipAndLoadScene(int x)
    {
        PlayClip();
        StartCoroutine(LoadAfterClipWasPlayed(x));
    }
    IEnumerator LoadAfterClipWasPlayed(int x)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        gameManager.LoadLevel(x);
    }
}
