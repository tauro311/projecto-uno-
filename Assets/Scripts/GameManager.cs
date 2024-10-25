using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Text _textCoin;
    [SerializeField] Text _textMagic;


    private int coins = 0; 
    private int magic = 0;
    private bool isPaused;
    [SerializeField]GameObject _pauseCanvas;
    [SerializeField]private Slider _healthBar;

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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoadAsync("Main Menu"));

        }
    }
    public void Pause()
    {
        if(!isPaused)
        { 
            _pauseCanvas.SetActive(true);

            Time.timeScale = 0;
            isPaused = true;
           

        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            _pauseCanvas.SetActive(false);
        }

    }
 
    public void AddCoin()
    {
        coins++;
        _textCoin.text = coins.ToString();
        //coins += 1 ; ( es lo mismo )


    }
    public void AddMagic()
    {
        magic++;
        _textMagic.text = magic.ToString();
    }



    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


     public void SetHealBar(int maxHealth)
     {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
     }
     public void UpdateHealBar(int health)
     {
        _healthBar.value = health;
     }
     float progresoDeCarga;

     IEnumerator LoadAsync(string SceneName)
     {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress <= 0.9f)
            {
                progresoDeCarga = asyncLoad.progress;
                Debug.Log(progresoDeCarga);


            }
            yield return null;

        }
     }
}
