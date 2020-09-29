using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public int enemieskilled, maxenemies;
    public GameObject victorypanel, gameoverpanel;
    

    public static GameManager access;

    void Start()
    {
        victorypanel.SetActive(false);
        gameoverpanel.SetActive(false);
        access = this;
        enemieskilled = 0;
    }

    public void GameOver()
    {
        if(isPlaying == false) return;
        isPlaying = false;
        gameoverpanel.SetActive(true);        
        Debug.Log("C'est la loose !");
    }

    public void Victory()
    {
        if(isPlaying == false) return;
        isPlaying = false;   
        victorypanel.SetActive(true);     
        Debug.Log("C'est la victoire !");
    }

    
    

}
