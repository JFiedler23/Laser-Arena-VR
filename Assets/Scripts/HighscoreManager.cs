using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    //New high score variables
    private List<Highscore> highScores;
    private Highscore newHighScore;
    private HighscoreLoader loader;

    //References
    public TextMeshProUGUI highScoreText;
    public GameObject newHighScorePrefab;
    public TextMeshProUGUI nameText;
    public SceneLoader sceneLoader;

    void Start()
    {
        //Creating our loader object
        loader = new HighscoreLoader();

        //Getting list of high scores
        highScores = loader.LoadHighScores();

        Scene currentScene = SceneManager.GetActiveScene();

        //Depending on scene, call appropriate function
        if (currentScene.name == "High Scores")
        {
            DisplayHighScores();
        }
        else if(currentScene.name == "New High Score")
        {
            newHighScorePrefab = GameObject.FindGameObjectWithTag("New High Score");
            newHighScore = new Highscore();
            newHighScore.score = newHighScorePrefab.GetComponent<NewHighScore>().newHighScore;
        }
    }

    void DisplayHighScores()
    {
        if(highScores != null)
        {
            //Displaying high scores list
            foreach (Highscore score in highScores)
            {
                highScoreText.text += score.name + " " + score.score + "\n";
            }
        }
    }

    public bool CheckHighScores(int playerScore)
    {
        //If there is a highscores file
        if(highScores != null)
        {
            foreach (Highscore score in highScores)
            {
                if (playerScore > score.score)
                {
                    //Getting index of new high score spot and new high score
                    newHighScorePrefab.GetComponent<NewHighScore>().indexOfNewHighScore = highScores.IndexOf(score);
                    newHighScorePrefab.GetComponent<NewHighScore>().newHighScore = playerScore;

                    //Perserving new high score object
                    DontDestroyOnLoad(newHighScorePrefab);

                    return true;
                }
            }
            return false;
        }
        //If there is not a highscores file
        else
        {
            //Getting index of new high score spot and new high score
            newHighScorePrefab.GetComponent<NewHighScore>().indexOfNewHighScore = 0;
            newHighScorePrefab.GetComponent<NewHighScore>().newHighScore = playerScore;

            //Perserving new high score object
            DontDestroyOnLoad(newHighScorePrefab);
            return true;
        }
    }

    public void AddLetter(string letter)
    {
        newHighScore.name += letter;
        nameText.text = newHighScore.name;
    }
    public void RemoveLetter()
    {
        newHighScore.name = newHighScore.name.Remove(newHighScore.name.Length - 1, 1);
        nameText.text = newHighScore.name;
    }

    public void AddHighScore()
    {
        int index = newHighScorePrefab.GetComponent<NewHighScore>().indexOfNewHighScore;

        if(highScores != null)
        {
            //Only allowing there to be 10 highscores total
            if(highScores.Count >= 10)
            {
                //popping lowest high score off list
                highScores.RemoveAt(highScores.Count - 1);
            }
            //Inserting new high score at appropriate spot in list
            highScores.Insert(index, newHighScore);
        }
        else
        {
            highScores = new List<Highscore>();
            highScores.Add(newHighScore);
        }

        //Passing in highscores list to save them to json file
        loader.SaveHighScores(highScores);

        //Once new score is added to list, load high score screen
        sceneLoader.LoadHighScoreScene();
    }
}
