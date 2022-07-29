using UnityEngine;

[CreateAssetMenu(fileName = "Brick", menuName = "ScriptableObject/Brick")]
public class BricksScriptableObject : ScriptableObject
{
    public int health;
    public bool isBreakable;
    public bool hasPowerup;
}
