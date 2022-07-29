using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    public void Back()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void Save()
    {

    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
