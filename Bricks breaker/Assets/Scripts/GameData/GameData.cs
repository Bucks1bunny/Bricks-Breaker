using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int lives;
    public SerializableDictionary<Vector3, int> dict;

    public GameData()
    {
        this.score = 0;
        this.lives = 3;
        dict = new SerializableDictionary<Vector3, int>();
    }
}
