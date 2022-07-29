using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private TextMeshProUGUI scoreUI;
    [SerializeField]
    private BrickManager brickManager;
    private int score = 0;

    private void Start()
    {
        brickManager.Scored += UpdateScore;
        Cursor.visible = false;
        pauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
    }

    private void UpdateScore(int _score)
    {
        score += _score;
        scoreUI.text = "Score:" + score.ToString();
    }
}
