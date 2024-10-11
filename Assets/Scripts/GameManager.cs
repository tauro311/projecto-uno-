using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int coins = 0; 
    private bool isPaused;
    

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

    }
    public void Pause()
    {

    }
 
    public void AddCoin()
    {
        coins++;
        //coins += 1 ; ( es lo mismo )

    }
}
