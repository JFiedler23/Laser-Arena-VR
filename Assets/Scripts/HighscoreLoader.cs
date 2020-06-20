using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreLoader
{
    private string SAVE_PATH = Application.dataPath + "/Saves/";
    private string FILE_NAME = "highscores.txt";

    public void SaveHighScores(List<Highscore> highscores)
    {
        string json;
        //Creating the save folder if it doesn't exist
        if(!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        //Removing old save file
        File.Delete(SAVE_PATH + FILE_NAME);

        foreach (Highscore highscore in highscores)
        {
            //Creating json string
            json = JsonUtility.ToJson(highscore) + "\n";

            //Appending it to the save file
            File.AppendAllText(SAVE_PATH + FILE_NAME, json);
        }
    }

    public List<Highscore> LoadHighScores()
    {
        List<Highscore> highscores = new List<Highscore>();

        if(!File.Exists(SAVE_PATH + FILE_NAME))
        {
            return null;
        }
        else
        {
            foreach (string json in File.ReadAllLines(SAVE_PATH + FILE_NAME))
            {
                highscores.Add(JsonUtility.FromJson<Highscore>(json));
            }
            return highscores;
        }
    }
}
