using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRandomAudioClip : MonoBehaviour {

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    private int playingID;

    private void Awake()
    {
        if (audioSource == null)
            audioSource = this.GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }
    public void PlayClip()
    {
        if (!audioSource.isPlaying)
        {
            playingID = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[playingID];
            audioSource.Play();

        }
    }
    public float ClipLength()
    {
        return audioClips[playingID].length;
    }
}
