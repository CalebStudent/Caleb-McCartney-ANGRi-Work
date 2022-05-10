using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private float t;


    public string bestTime1;
    public float seconds1;
    public float minutes1;
    public float BS1;
    public float BM1;
    private bool isFighting = true;

    private string _bestTime1;
    private string _bestTime2;
    private string _bestTime3;
    private float _bestMin1;
    private float _bestMin2;
    private float _bestMin3;
    private float _bestSec1;
    private float _bestSec2;
    private float _bestSec3;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        LoadData();
        if(BS1 == 0 && BM1 == 0)
        {
            BS1 = 59;
            BM1 = 999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFighting)
        {
            t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = "Time: " + minutes + ":" + seconds;
        }
    }

    public void endTime1()
    {
        isFighting = false;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        minutes1 = (int)t / 60;
        seconds1 = t % 60;

        bestTime1 = minutes + ":" + seconds;
        if (minutes1 <= BM1)
        { 
            if(seconds1 <= BS1)
            {
                SaveData();
            }
            else if(minutes1 < BM1)
            SaveData();
        }
        wall.SetActive(true);
    }

    void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        SaveData data = new SaveData();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            data.bestTime1 = bestTime1;
            data.bestminutes1 = minutes1;
            data.bestseconds1 = seconds1;


            data.bestTime2 = _bestTime2;
            data.bestminutes2 = _bestMin2;
            data.bestseconds2 = _bestSec2;
            
            data.bestTime3 = _bestTime3;
            data.bestminutes3 = _bestMin3;
            data.bestseconds3 = _bestSec3;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            data.bestTime2 = bestTime1;
            data.bestminutes2 = minutes1;
            data.bestseconds2 = seconds1;

            data.bestTime1 = _bestTime1;
            data.bestminutes1 = _bestMin1;
            data.bestseconds1 = _bestSec1;

            data.bestTime3 = _bestTime3;
            data.bestminutes3 = _bestMin3;
            data.bestseconds3 = _bestSec3;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            data.bestTime3 = bestTime1;
            data.bestminutes3 = minutes1;
            data.bestseconds3 = seconds1;

            data.bestTime2 = _bestTime2;
            data.bestminutes2 = _bestMin2;
            data.bestseconds2 = _bestSec2;

            data.bestTime1 = _bestTime1;
            data.bestminutes1 = _bestMin1;
            data.bestseconds1 = _bestSec1;
        }
        
        bf.Serialize(file, data);
        file.Close();
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
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                bestTime1 = data.bestTime1;
                BS1 = data.bestseconds1;
                BM1 = data.bestminutes1;

                _bestTime1 = data.bestTime1;
                _bestTime2 = data.bestTime2;
                _bestTime3 = data.bestTime3;

                _bestMin1 = data.bestminutes1;
                _bestMin2 = data.bestminutes2;
                _bestMin3 = data.bestminutes3;

                _bestSec1 = data.bestseconds1;
                _bestSec2 = data.bestseconds2;
                _bestSec3 = data.bestseconds3;


            } else if(SceneManager.GetActiveScene().buildIndex == 2)
            {
                bestTime1 = data.bestTime2;
                BS1 = data.bestseconds2;
                BM1 = data.bestminutes2;

                _bestTime1 = data.bestTime1;
                _bestTime2 = data.bestTime2;
                _bestTime3 = data.bestTime3;

                _bestMin1 = data.bestminutes1;
                _bestMin2 = data.bestminutes2;
                _bestMin3 = data.bestminutes3;

                _bestSec1 = data.bestseconds1;
                _bestSec2 = data.bestseconds2;
                _bestSec3 = data.bestseconds3;


            } else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                bestTime1 = data.bestTime3;
                BS1 = data.bestseconds3;
                BM1 = data.bestminutes3;

                _bestTime1 = data.bestTime1;
                _bestTime2 = data.bestTime2;
                _bestTime3 = data.bestTime3;

                _bestMin1 = data.bestminutes1;
                _bestMin2 = data.bestminutes2;
                _bestMin3 = data.bestminutes3;

                _bestSec1 = data.bestseconds1;
                _bestSec2 = data.bestseconds2;
                _bestSec3 = data.bestseconds3;

            }
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
class SaveData
{
    public string bestTime1;
    public float bestminutes1;
    public float bestseconds1;

    public string bestTime2;
    public float bestminutes2;
    public float bestseconds2;

    public string bestTime3;
    public float bestminutes3;
    public float bestseconds3;
}
