using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;    
    public string playerName;
    public int bestScore;
    public string bestPlayerName;

    private void Awake() {
        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject); 

        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        public string bestPlayerName;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
