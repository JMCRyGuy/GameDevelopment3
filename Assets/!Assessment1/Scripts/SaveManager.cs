using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int highScore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

        }
        DontDestroyOnLoad(gameObject);
        Load();

    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/info.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/info.dat", FileMode.Open);
            Data_Storage data = (Data_Storage)bf.Deserialize(file);

            highScore = data.highScoreData;

            file.Close();

        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/info.dat");
        Data_Storage data = new Data_Storage();

        data.highScoreData = highScore;

        bf.Serialize(file, data);
        file.Close();

    }


    

}


[Serializable]

class Data_Storage
{
    public int highScoreData;
}