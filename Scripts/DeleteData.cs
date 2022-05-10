using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour
{
   

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
}
