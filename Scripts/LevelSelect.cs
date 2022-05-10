using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void LoadThisLev(int lev)
    {
        SceneManager.LoadScene(lev);
        FindObjectOfType<AudioManager>().Play("Game Start Button");
        FindObjectOfType<AudioManager>().Play("Level Music");
    }

    
}
