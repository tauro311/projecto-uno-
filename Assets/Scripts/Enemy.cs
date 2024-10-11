using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int vidaEnemigo = 5;
    private AudioSource _audioSource;

 void Awake()
 {
    _audioSource = GetComponent<AudioSource>();
 } 
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySFX(_audioSource, SoundManager.instance.mimikAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void TakeDamage()
    {
        vidaEnemigo -= 1;

        if(vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
