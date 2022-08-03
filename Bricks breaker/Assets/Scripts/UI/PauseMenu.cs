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
        DataManager.instance.SaveGame();
    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
