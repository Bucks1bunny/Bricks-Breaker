using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public int Score
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private TextMeshProUGUI scoreUI;
    [SerializeField]
    private 

    private void Awake()
    {
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

    private void UpdateScore()
    {
        scoreUI.text = "Score:" + Score.ToString();
    }
}
