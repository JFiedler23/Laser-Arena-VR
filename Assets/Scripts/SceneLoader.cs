
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadHighScoreScene()
    {
        SceneManager.LoadScene("High Scores");
    }

    public void LoadNewHighScoreScene()
    {
        SceneManager.LoadScene("New High Score");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }
}
