 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    public AudioClip jump;
    public AudioClip gravSwap;

    public void PlaySFX(AudioClip clip){
    sfxSource.PlayOneShot(clip);
    }
}
