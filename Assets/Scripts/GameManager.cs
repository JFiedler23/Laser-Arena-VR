using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Text variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject gameCanvas;
    public GameObject welcomeCanvas;

    //Gameplay variables
    public int score = 0;
    public float gameTime = 60f; //60 seconds per game
    public bool startGame = false;

    //References
    public TargetManager targetManager;
    public HighscoreManager highscoreManager;
    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: \n" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has picked up the gun, begin counting down
        if(startGame)
        {
            GameTimer();
        }
    }

    public void AddToScore(int targetValue)
    {
        //Adding to score based on the value of the destroyed target
        score += targetValue;
        scoreText.text = "Score: \n" + score.ToString();
    }

    void GameTimer()
    {
        //Counting down the timer
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        //Timer runs out. End game
        else
        {
            targetManager.startSpawning = false;

            //Checking if the player has set a new high score
            if(highscoreManager.CheckHighScores(score))
            {
                sceneLoader.LoadNewHighScoreScene();
            }
            //If not, load game over scene
            else
            {
                sceneLoader.LoadGameOverScene();
            }
        }

        //Displaying the time left
        timeText.text = "Time Left: \n" + gameTime.ToString("f0");
    }

    //Used to determine when the player has picked up the gun to start the game
    public void StartGame()
    {
        welcomeCanvas.SetActive(false);
        gameCanvas.SetActive(true);

        startGame = true;
        targetManager.startSpawning = true;
    }
}
