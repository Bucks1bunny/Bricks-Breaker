using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Button buttonContinue;

    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

    public void NewGame()
    {
        DataManager.instance.NewGame();
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        string path = Application.persistentDataPath + "/data.game";

        if (!File.Exists(path))
        {
            buttonContinue.interactable = false;
        }
        else
        {
            buttonContinue.interactable = true;
        }
    }
}
