using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    private PlayerController playerScript;


[SerializeField]private int _health = 1;
    // Update is called once per frame
    void ONTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            playerScript = collider.gameObject.GetComponent<PlayerController>();

            playerScript.AtHealth(1);
            Destroy(gameObject);
        }
    }
    
     
}
