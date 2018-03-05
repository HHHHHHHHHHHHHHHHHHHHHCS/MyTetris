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
    [SerializeField]
    private AudioClip lineClearClip;

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

    public void PlayLineClean()
    {
        PlayAudio(lineClearClip);
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
