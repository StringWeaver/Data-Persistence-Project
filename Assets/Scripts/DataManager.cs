using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public string PlayerName;
    public string HighestScoreName;
    public int HighestScore;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        HighestScore = 0;
        DontDestroyOnLoad(gameObject);
        LoadDataFromFile();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighestScoreName;
        public int HighestScore;
    }

    public void SaveDataToFile()
    {
        SaveData data = new SaveData
        {
            HighestScoreName = HighestScoreName,
            HighestScore = HighestScore
        };
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }
    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighestScore = data.HighestScore;
            HighestScoreName = data.HighestScoreName;
        }
    }

    public void ClearHighestScore()
    {
        HighestScoreName = null;
        HighestScore = 0;
        SaveDataToFile();
    }
}
