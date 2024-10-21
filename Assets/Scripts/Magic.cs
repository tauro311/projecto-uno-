using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private bool interactible;
   

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            interactible = true;
           SoundManager.instance.PlaySFX(SoundManager.instance._audioSource,SoundManager.instance.coinAudio);

        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            interactible = false;
        }

    }
}
