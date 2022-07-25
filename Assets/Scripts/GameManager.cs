using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    
    public Text ScoreText;
    public int bestScore;
    public string bestName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();


    }
    private void Update()
    {
       

    }
    public void NameSaved(string name)
    {
        GameManager.Instance.playerName = name;  
    }
    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestName;
    }
    public void SaveBestScore(int score)
    {
    if (score > GameManager.Instance.bestScore)
        {
            GameManager.Instance.bestScore = score;
            GameManager.Instance.bestName = GameManager.Instance.playerName;
            SaveData data = new SaveData();
            data.bestScore = bestScore;
            data.bestName = bestName;
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestName = data.bestName;
        }
    }
}
