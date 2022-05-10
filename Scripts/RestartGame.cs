using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    Scene currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
    }

   

    public void reloadLevel()
    {
        SceneManager.LoadScene(currentLevel.name);
    }
}
