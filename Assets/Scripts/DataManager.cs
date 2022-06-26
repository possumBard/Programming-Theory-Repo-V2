using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string winnerName;
    public int highScore;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    // SAVING HIGH SCORE DATA
    [System.Serializable]
    class SaveData
    {
        public string winnerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.winnerName = winnerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            winnerName = data.winnerName;
            highScore = data.highScore;
        }
    }



}
