using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class loadTime2 : MonoBehaviour
{
    public Text bestTime2Text;
    public string bestTime2;
    public GameObject Level3;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        if (bestTime2 == null)
        {
            bestTime2Text.text = "Best Time: 00:00";
        }
        else
        {
            bestTime2Text.text = "Best Time: " + bestTime2;
            Level3.SetActive(true);
        }
    }


    void LoadData()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            bestTime2 = data.bestTime2;
        }
        else
            Debug.LogError("There is no save data!");
    }
}