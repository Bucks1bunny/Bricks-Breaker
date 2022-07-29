using UnityEngine;

[CreateAssetMenu(fileName = "Brick", menuName = "ScriptableObject/Brick")]
public class BricksScriptableObject : ScriptableObject
{
    public int health;
    public int score;
    public bool isBreakable;
    public bool hasPowerup;
}
