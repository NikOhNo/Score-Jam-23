using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer instance;

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip pickUpSFX;

    [SerializeField]
    AudioClip hurtSFX;

    [SerializeField]
    AudioClip explosionSFX;

    [SerializeField]
    AudioClip timeSlowSFX;

    private void Awake()
    {
        instance = this;

        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayPickUpSFX()
    {
        myAudioSource.PlayOneShot(pickUpSFX);
    }

    public void PlayHurtSFX()
    {
        myAudioSource.PlayOneShot(hurtSFX);
    }

    public void PlayExplosionSFX()
    {
        myAudioSource.PlayOneShot(explosionSFX);
    }

    public void PlayTimeSlowSFX()
    {
        myAudioSource.PlayOneShot(timeSlowSFX);
    }
}
