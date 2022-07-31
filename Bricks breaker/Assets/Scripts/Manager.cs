using UnityEngine;

public class Manager : MonoBehaviour
{
    [field: SerializeField]
    public BrickManager BrickManager
    {
        get;
        private set;
    }
    [field: SerializeField]
    public ResetBall ResetBall
    {
        get;
        private set;
    }
    [field: SerializeField]
    public EndGame EndGameUI
    {
        get;
        private set;
    }
    [field: SerializeField]
    public GameUI GameUI
    {
        get;
        private set;
    }
    [field:SerializeField]
    public Game Data
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject pauseUI = null;
    [SerializeField]
    private GameObject endGameUI = null;

    private void Start()
    {
        BrickManager.Scored += UpdateScore;
        BrickManager.AllBricksDestoyed += EndGame;
        ResetBall.BallPassed += OnHealthLost;
        GameUI.HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HIGHSCORE").ToString();

        Cursor.visible = false;
        pauseUI.SetActive(false);
        endGameUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            TurnOnCursor();
        }
    }

    private void UpdateScore(int _score)
    {
        Data.Score += _score;
        GameUI.ScoreText.text = "Score:" + Data.Score.ToString();
    }

    private void EndGame(bool win)
    {
        endGameUI.SetActive(true);
        EndGameUI.EndScoreText.text = "Score:" + Data.Score.ToString();
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (Data.Score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", Data.Score);
        }
        EndGameUI.Highscore.text = "HighScore: " + highScore.ToString();
        TurnOnCursor();
        if (win)
        {
            EndGameUI.EndGameText.text = "YOU WIN";
        }
        else
        {
            EndGameUI.EndGameText.text = "GAME OVER";
        }
    }

    private void TurnOnCursor()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void OnHealthLost()
    {
        Data.Lives--;
        GameUI.LivesText.text = "Lives: " + Data.Lives.ToString();
        if (Data.Lives == 0)
        {
            EndGame(false);
        }
    }
}
