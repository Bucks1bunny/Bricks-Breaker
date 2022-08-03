using UnityEngine;

public class Manager : MonoBehaviour, IDataPersistence
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

    [SerializeField]
    private GameObject pauseUI = null;
    [SerializeField]
    private GameObject endGameUI = null;
    private int score;
    private int lives;

    public void LoadData(GameData data)
    {
        this.score = data.score;
        this.lives = data.lives;
        SetScore(score);
        SetLives(lives);
    }

    public void SaveData(GameData data)
    {
        data.lives = this.lives;
        data.score = this.score;
    }

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

    private void SetScore(int _score)
    {
        this.score = _score;
        GameUI.ScoreText.text = "Score:" + score.ToString();
    }

    private void SetLives(int _lives)
    {
        this.lives = _lives;
        GameUI.LivesText.text = "Lives:" + lives.ToString();
    }

    private void EndGame(bool win)
    {
        endGameUI.SetActive(true);
        EndGameUI.EndScoreText.text = "Score:" + score.ToString();

        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
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

    private void UpdateScore(int _score)
    {
        this.score += _score;
        GameUI.ScoreText.text = "Score:" + score.ToString();
    }

    private void OnHealthLost()
    {
        lives--;
        GameUI.LivesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            EndGame(false);
        }
    }
}
