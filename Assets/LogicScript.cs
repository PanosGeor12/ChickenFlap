using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public GameObject gameOverScreen;
    public GameObject exitGameScreen;
    public GameObject startGameScreen;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void startGame()
    {
        Time.timeScale = 1;
        startGameScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void cloceModal()
    {
        Time.timeScale = 1;
        exitGameScreen.SetActive(false);
    }
}
