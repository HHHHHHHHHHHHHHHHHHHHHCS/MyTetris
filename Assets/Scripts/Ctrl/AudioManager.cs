using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip cursorClip;
    [SerializeField]
    private AudioClip dropClip;

    private AudioSource audioSource;

    private bool isMute;

    public AudioManager Init()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = isMute ? 0 : 1;
        return this;
    }

    public void PlayCursor()
    {
        PlayAudio(cursorClip);
    }

    public void PlayDrop()
    {
        PlayAudio(dropClip);
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
