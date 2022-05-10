using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class loadTime1 : MonoBehaviour
{
    public Text bestTime1Text;
    public string bestTime1;
    public GameObject Level2;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        if (bestTime1 == "")
        {
            bestTime1Text.text = "Best Time: 00:00";
        }
        else
        {
            bestTime1Text.text = "Best Time: " + bestTime1;
            Level2.SetActive(true);
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
            bestTime1 = data.bestTime1;
        }
        else
            Debug.LogError("There is no save data!");
    }
}
