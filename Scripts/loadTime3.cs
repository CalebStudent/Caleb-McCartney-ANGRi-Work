using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class loadTime3 : MonoBehaviour
{
    public Text bestTime3Text;
    public string bestTime3;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        if (bestTime3 == null)
        {
            bestTime3Text.text = "Best Time: 00:00";
        }
        else
        {
            bestTime3Text.text = "Best Time: " + bestTime3;
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
            bestTime3 = data.bestTime3;
        }
        else
            Debug.LogError("There is no save data!");
    }
}
