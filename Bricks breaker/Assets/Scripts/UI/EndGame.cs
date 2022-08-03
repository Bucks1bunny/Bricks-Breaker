using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    [field: SerializeField]
    public TextMeshProUGUI EndScoreText
    {
        get;
        private set;
    }
    [field: SerializeField]
    public TextMeshProUGUI EndGameText
    {
        get;
        private set;
    }
    [field: SerializeField]
    public TextMeshProUGUI Highscore
    {
        get;
        private set;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
