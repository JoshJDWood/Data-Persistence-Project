using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TopManager : MonoBehaviour
{
    private const string defName = "a";
    private const int defScore = 0;
    public static TopManager Instance;

    public List<ScoreData> HighScores = new List<ScoreData> { new ScoreData { score = defScore, name = defName },
        new ScoreData { score = defScore, name = defName }, new ScoreData { score = defScore, name = defName } };

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
    }

    [System.Serializable]
    public class ScoreData
    {
        public int score;
        public string name;
    }

    [System.Serializable]
    class SaveData
    {
        public ScoreData first;
        public ScoreData second;
        public ScoreData third;
    }

    public void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.first = Instance.HighScores[0];
        data.second = Instance.HighScores[1];
        data.third = Instance.HighScores[2];

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instance.HighScores[0] = data.first;
            Instance.HighScores[1] = data.second;
            Instance.HighScores[2] = data.third;
        }
    }
}
