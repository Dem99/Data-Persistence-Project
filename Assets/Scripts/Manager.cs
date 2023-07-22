using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public InputField nameText;
    public static int bestScore;
    public static string bestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadResult();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveResult(int score)
    {
        if (bestScore == 0 || bestScore < score)
        {
            SaveData data = new SaveData();
            data.name = nameText.text;
            data.score = score;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        } 
        
    }

    public void LoadResult()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameText.text = data.name;
            bestScore = data.score;
            bestPlayer = data.name;
        }
    }
}
