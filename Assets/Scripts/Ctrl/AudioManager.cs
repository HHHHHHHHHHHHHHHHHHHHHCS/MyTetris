using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip cursorClip;
    [SerializeField]
    private AudioClip dropClip;
    [SerializeField]
    private AudioClip controlClip;

    private AudioSource audioSource;

    private bool isMute;

    public AudioManager Init()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = isMute ;
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
    public void PlayControl()
    {
        PlayAudio(controlClip);
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
