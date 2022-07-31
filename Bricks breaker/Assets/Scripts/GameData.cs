using System;

[Serializable]
public class GameData
{
    public int score;
    public int lives;

    public GameData(Game game)
    {
        score = game.Score;
        lives = game.Lives;
    }
}
