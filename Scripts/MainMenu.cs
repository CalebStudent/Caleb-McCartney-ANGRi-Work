using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }

    public void deleteStart(GameObject DMenu)
    {
        DMenu.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Game Start Button");
    }

    public void abortDelete()
    {
        GameObject deleteMenu = GameObject.Find("DeleteDataMenu");
        deleteMenu.SetActive(false);
    }

    public void deleteSave()
    {

        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                       + "/MySaveData.dat");
            SceneManager.LoadScene(0);
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void switchToCredits(GameObject credits)
    {
        credits.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Game Start Button");
        this.transform.parent.gameObject.SetActive(false);
    }
}
