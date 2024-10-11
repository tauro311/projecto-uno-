using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int vidaEnemigo = 3;

    // Start is called before the first frame update
    void Start()
    {
        
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
