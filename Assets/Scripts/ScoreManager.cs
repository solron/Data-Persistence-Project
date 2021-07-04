using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int scoreValue;
    public string playerName;
    public string currentPlayer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class SaveScore
    {
        public int scoreValue;
        public string playerName;
    }

    public void SaveScoreValue()
    {
        SaveScore score = new SaveScore();
        score.playerName = playerName;
        score.scoreValue = scoreValue;

        string json = JsonUtility.ToJson(score);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreValue()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore score = JsonUtility.FromJson<SaveScore>(json);
            scoreValue = score.scoreValue;
            playerName = score.playerName;
        }
    }
}
