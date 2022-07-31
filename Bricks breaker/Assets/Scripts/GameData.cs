using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int score;
    public int lives;
    public Dictionary<Transform, Brick> bricksPosition = new Dictionary<Transform, Brick>();

    public GameData(Game game)
    {
        score = game.Score;
        lives = game.Lives;
        bricksPosition = game.bricksPosition;
    }
}
