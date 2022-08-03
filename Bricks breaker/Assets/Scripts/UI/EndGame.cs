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
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
