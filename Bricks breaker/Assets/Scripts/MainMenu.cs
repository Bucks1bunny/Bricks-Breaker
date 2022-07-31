using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Button buttonContinue;

    private void Start()
    {
        string path = Application.persistentDataPath + "/game.fun";
        if (!File.Exists(path))
        {
            buttonContinue.enabled = false;
        }
        else
        {
            buttonContinue.enabled = true;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
