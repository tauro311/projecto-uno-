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
        if(Collider.gameObject.CompareTag("Player"))
        {
            interactible = true
            GameManager.instance.PlaySFX()

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
