using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
  public static BGManager instance ; 
  private AudioSource _audioSource;

  void Awake()
  {
    if(instance != null && instance != this)
    {
        Destroy(gameObject);

    }
    else 
    {
        instance = this; 

    }
    _audioSource = GetComponent<AudioSource>();
  }

  public void PlayBGM(AudioClip clip)
  {
    _audioSource.clip = clip; 
    _audioSource.Play();

  }
}
