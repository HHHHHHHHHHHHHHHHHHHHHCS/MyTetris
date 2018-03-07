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

    public bool IsMute
    {
        get
        {
            return audioSource.mute;
        }

        set
        {
            audioSource.mute = value;
        }
    }


    public AudioManager Init()
    {
        audioSource = GetComponent<AudioSource>();
        return this;
    }

    public void SwitchMuteAudio()
    {
        IsMute = !IsMute;
    }

    public void ChangeMuteAudio(bool tf = false)
    {
        IsMute = tf;
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
