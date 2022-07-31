using UnityEngine;

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

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        Score = data.score;
        Lives = data.lives;
    }
}
