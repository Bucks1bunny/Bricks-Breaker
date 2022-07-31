using UnityEngine;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public int Score
    {
        get;
        set;
    } = 0;
    public int Lives
    {
        get;
        set;
    } = 3;

    public Dictionary<Transform, Brick> bricksPosition = new Dictionary<Transform, Brick>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        Score = data.score;
        Lives = data.lives;
        bricksPosition = data.bricksPosition;

    }
}
